using UnityEngine;
using System.Collections;



public class TBR_VehicleControllerMKII : MonoBehaviour {

    public class mirror : MonoBehaviour
    {

        string name = "Mirror";
        Transform pntr;
        Vector3 pos;
        Rect rect;// = new Rect(0.86f, 0.04f, 0.2f, 0.2f);
        float fov = 30.0f;
        float clippingPlane = 3.5f;

        Camera camera;



        internal void create(Transform obj)
        {
            camera.enabled = true;

            pos = obj.transform.InverseTransformPoint(pntr.position);

            GameObject tempobj = new GameObject("Mirror_" + name);
            tempobj.transform.parent = obj.transform;
            tempobj.transform.parent = obj.transform;
            tempobj.transform.localPosition = pos;
            tempobj.transform.LookAt(obj.transform.TransformPoint(pos - Vector3.forward));
            camera = tempobj.AddComponent("Camera") as Camera;
            camera.depth = 7;
            camera.rect = rect;
            camera.fieldOfView = fov;
            camera.nearClipPlane = clippingPlane;
            tempobj.AddComponent("TBR_RearViewProperties");
        }

        internal void enabled(bool p)
        {
            camera.enabled = p;
        }
    }

    public bool blIsPlayer_b = false;
    public bool blIsAI_b = false;

    public float flMass_b = 2200.0f;
     
    public Transform trCenterOfMass;

    //wheel opperations
    public WheelCollider[] wheels;
    public GameObject[] wheelMesh;
    

    public Light[] liBrakeLight_b;

    private float flThrottle_v;
    private float flSteer_v;

    public float flEnginePower_b = 150.0f;//power
    public float flMaxSteerAngle_b = 15.0f;

    public float flBrakeAmmount_b = 0.5f;

    public float flMaxSpeed_b = 45.0f;

    private float flWheelPower_v = 0.0f;
    private float flWheelBrake_v = 0.0f;
    private float flSteerAngle_v = 0.0f;

    
    private float[] rotationValue = new float[4];

    

    private float flDownForce_r = 0.0f;
    private float flDragForce_r = 0.0f;

    public float flDragCoeffeficient_b = 0.5f;

    public AnimationCurve acDragCurve_b = new AnimationCurve(
        new Keyframe(0,0,0,0),
        new Keyframe(0.562442f,0.0f,0.0f,0.0f),
        new Keyframe(0.8814013f, 0.1533709f, 0.585059f, 0.585059f),
        new Keyframe(1.0f, 0.5f, 4.387755f, 4.387755f));

    public float flMinEngineRPM_b = 1000.0f;
    public float flMaxEngineRPM_b = 3000.0f;
    public float flEngineRPM_b = 0.0f;

    //AI Requirements

    public GameObject[] goAIWaypoints_v;
    public int intNextWaypoint_v = 0;

    public mirror miMirror_b;

    //start functions

    void getAIWaypoints()
    {
        goAIWaypoints_v = GameObject.FindGameObjectsWithTag("AIPath");
    }

    void massSetup()
    {
        if (trCenterOfMass)
        {
            rigidbody.centerOfMass = trCenterOfMass.localPosition;
            rigidbody.mass = flMass_b;
            wheelMesh[0].transform.Rotate(90.0f, 0.0f, 90.0f);
            wheelMesh[1].transform.Rotate(90.0f, 0.0f, 90.0f);
        }
    }

    void wheelSetup()
    {

        foreach (WheelCollider wc in wheels)
        {

            wc.suspensionDistance = 0.25f;
            
            


        }

    }

    //update

    void getPlayerInputs()
    {
        flThrottle_v = Input.GetAxis("Vertical");
        
        flSteer_v = Input.GetAxis("Horizontal");

        
    }

    void getAIInputs(Vector3 relativeVelocity)
    {
        //Debug.Log(relativeVelocity);
        for (int i = 0; i < goAIWaypoints_v.Length; ++i)
        {
            //waypoint detection
            if (goAIWaypoints_v[i].transform.GetComponent<TBR_AINode>().intAINodeTag_b == intNextWaypoint_v)
            {
                Vector3 RelativeWaypointPos = transform.InverseTransformPoint(new Vector3(
                    goAIWaypoints_v[i].transform.position.x,
                    goAIWaypoints_v[i].transform.position.y,
                    goAIWaypoints_v[i].transform.position.z));

                flSteer_v = -RelativeWaypointPos.z / RelativeWaypointPos.magnitude;

                if (Mathf.Abs(flSteer_v) < 0.5f)
                {
                    RaycastHit hit;

                    Debug.DrawRay(trCenterOfMass.position, trCenterOfMass.forward * (relativeVelocity.magnitude*2), Color.blue);
                    if (Physics.Raycast(trCenterOfMass.position, trCenterOfMass.forward, out hit, relativeVelocity.magnitude*2))
                    {
                        Debug.DrawRay(transform.position, Vector3.right);
                        //float dist = hit.distance;
                        
                        if (relativeVelocity.magnitude > flMaxSpeed_b/* && hit.collider.gameObject.tag == "AIPath"*/)
                        {
                            //if(
                            flThrottle_v = -1;
                            
                            
                        }
                        else
                        {
                            flThrottle_v = RelativeWaypointPos.x / RelativeWaypointPos.magnitude - Mathf.Abs(flSteer_v);
                        }
                        //
                    }

                    else
                    {
                        
                    }
                    flThrottle_v = RelativeWaypointPos.x / RelativeWaypointPos.magnitude - Mathf.Abs(flSteer_v);
                }
                else
                {
                    flThrottle_v = 0.0f;
                }

                

                if (RelativeWaypointPos.magnitude < 20)
                {
                    intNextWaypoint_v++;

                    if (intNextWaypoint_v >= goAIWaypoints_v.Length)
                    {
                        intNextWaypoint_v = 0;
                    }
                }
            }

            //ray functions


        }
    }

    //fixed update functions

    void calculateDownForce(Vector3 RelativeVelocity)
    {

        //Downforce = 1/2 * Surface Aea * Drag Coefficient * Air Density(1.226) * Speed^2 http://www.ehow.com/how_5128030_calculate-downforce.html
        flDownForce_r = (1.0f / 2.0f) * 10.0f * flDragCoeffeficient_b * (Vector3.Magnitude(RelativeVelocity) * Vector3.Magnitude(RelativeVelocity));
        //Debug.Log(flDownForce_r);
        transform.rigidbody.AddRelativeForce(new Vector3(0, -flDownForce_r, 0));
    }

    void calculateDragForce(Vector3 RelativeVelocity)
    {

        // Drag force = 1/2 * mass density * velocity^2 * Drag Coefficient * reference area http://en.wikipedia.org/wiki/Drag_equation http://www.ehow.com/how_6149160_calculate-drag.html

        //flDragForce_r = (1.0f / 2.0f) * Vector3.Dot(RelativeVelocity, RelativeVelocity) * flDragCoeffeficient_b /* flSurfaceArea_b*/;
        //Debug.Log(-flDragForce_r);
        //transform.rigidbody.AddRelativeForce(new Vector3(-flDragForce_r, 0, 0));
        transform.rigidbody.drag = (Mathf.Clamp01(acDragCurve_b.Evaluate(RelativeVelocity.x / flMaxSpeed_b))) ;

    }

    void carControl(Vector3 relativeVelocity)
    {

        bool isBreaking;

        flWheelPower_v = flThrottle_v * flEnginePower_b * Time.deltaTime * 250.0f;
        
        flSteerAngle_v = flSteer_v * flMaxSteerAngle_b;

        if(flThrottle_v >= 0){

            isBreaking = false;
        
        } else {

            isBreaking = true;

        }

        wheels[0].steerAngle = flSteerAngle_v;
        wheels[1].steerAngle = flSteerAngle_v;

        if (!isBreaking)
        {

            if (relativeVelocity.x >= 0.0f)
            {

                wheels[0].brakeTorque = 0;
                wheels[1].brakeTorque = 0;
                wheels[2].brakeTorque = 0;
                wheels[3].brakeTorque = 0;
                wheels[2].motorTorque = flWheelPower_v;
                wheels[3].motorTorque = flWheelPower_v;


            }
            else
            {

                wheels[2].motorTorque = 0;
                wheels[3].motorTorque = 0;
                wheels[0].brakeTorque = (5 * (Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b)) / 16;
                wheels[1].brakeTorque = (5 * (Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b)) / 16;
                wheels[2].brakeTorque = (5 * Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b);
                wheels[3].brakeTorque = (5 * Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b);

            }
            if (liBrakeLight_b != null)
            {
                foreach (Light l in liBrakeLight_b)
                {
                    l.intensity = 1;
                }
            }

        }

        else if(isBreaking)
        {

            if (relativeVelocity.x >= 2.0f)
            {

                wheels[2].motorTorque = 0;
                wheels[3].motorTorque = 0;
                wheels[0].brakeTorque = (5 * (Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b)) / 8;
                wheels[1].brakeTorque = (5 * (Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b)) / 8;
                wheels[2].brakeTorque = (5 * Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b);
                wheels[3].brakeTorque = (5 * Mathf.Abs(flThrottle_v) * transform.rigidbody.mass * flBrakeAmmount_b);
            
            }
            else
            {
                wheels[0].brakeTorque = 0;
                wheels[1].brakeTorque = 0;
                wheels[2].brakeTorque = 0;
                wheels[3].brakeTorque = 0;
                wheels[2].motorTorque = flWheelPower_v;
                wheels[3].motorTorque = flWheelPower_v;
               

            }
            
            
            if (liBrakeLight_b != null)
            {
                foreach (Light l in liBrakeLight_b)
                {
                    l.intensity = 8;
                }
            }
        }

    }

    void animateWheels()
    {
        
        {
            wheelMesh[0].transform.rotation = wheels[0].transform.rotation * Quaternion.Euler(0, wheels[0].steerAngle - 90.0f, -rotationValue[0]);
            wheelMesh[1].transform.rotation = wheels[0].transform.rotation * Quaternion.Euler(0, wheels[0].steerAngle - 90.0f, -rotationValue[0]);
        }
        rotationValue[0] += wheels[0].rpm * (360.0f / 60.0f) * Time.deltaTime;

        {
            wheelMesh[2].transform.rotation = wheels[1].transform.rotation * Quaternion.Euler(0, wheels[1].steerAngle + 90.0f, rotationValue[1]);
            wheelMesh[3].transform.rotation = wheels[1].transform.rotation * Quaternion.Euler(0, wheels[1].steerAngle + 90.0f, rotationValue[1]);
        }
        rotationValue[1] += wheels[1].rpm * (360.0f / 60.0f) * Time.deltaTime;

            
        {
            wheelMesh[4].transform.rotation = wheels[2].transform.rotation * Quaternion.Euler(0, wheels[2].steerAngle - 90.0f, -rotationValue[2]);
            wheelMesh[5].transform.rotation = wheels[2].transform.rotation * Quaternion.Euler(0, wheels[2].steerAngle - 90.0f, -rotationValue[2]);
        }
        rotationValue[2] += wheels[2].rpm * (360.0f / 60.0f) * Time.deltaTime;

            
        {
            wheelMesh[6].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
            wheelMesh[7].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
        }
        rotationValue[3] += wheels[3].rpm * (360.0f / 60.0f) * Time.deltaTime;
        
    }

    void Start()
    {


        massSetup();
        if (blIsAI_b)
        {
            getAIWaypoints();
        }
        else if (blIsPlayer_b)
        {
            //miMirror_b = new mirror();

            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (blIsPlayer_b && !blIsAI_b)
        {
            getPlayerInputs();
            
            //miMirror_b.create(trCenterOfMass);
            //miMirror_b.enabled(true);
           
        }

        else if (blIsAI_b && !blIsPlayer_b)
        {
            Vector3 relVel = transform.InverseTransformDirection(rigidbody.velocity);
            getAIInputs(relVel);
        }
    }

    void FixedUpdate()
    {

        Vector3 relVel =  transform.InverseTransformDirection(rigidbody.velocity);

        //Debug.Log(relVel.magnitude);

        carControl(relVel);

        animateWheels();
        calculateDownForce(relVel);
        calculateDragForce(relVel);

    }

}
