using UnityEngine;
using System.Collections;

public class TBR_CarController : MonoBehaviour
{
    private float flThrottle_v;
    private float flSteer_v;

    //new gear shifting tests

    public float flIdleRPM_b = 50;
    public float flMaxRPM_b = 250;
    public float flAcclRPM_b = 10;
    public int intNumGears_b = 4;

    private float flCurrentEquivilantRPM_v;
    private float flCurrentRPM_v;
    private int intCurrentGear_v;

    public float flMaxSpeed_b = 250.0f;

    public float flEnginePower_b = 335.0f;
    public float flTourque_b = 0.0f;

    public bool blIsPlayer_b = false;

    public float flMaxSteer_b = 25.0f;
    public float flMass_b = 2200.0f;
     
    public Transform trCenterOfMass;

    //wheel opperations
    public WheelCollider[] wheels;
    public GameObject[] wheelMesh;

    private bool blIsBraking_v = false;
    private float flCurrentSpeedL_v = 0.0f;
    private float flCurrentSpeedR_v = 0.0f;

    
    public float brake = 0.0f;
    public float minSteer = 0.0f;
    public float maxSteer = 25.0f;
    private float[] rotationValue = new float[4];

    //public int intNumGears_b = 4;
    
    
    //forces acting upon the vehicle

    public float flDragCoeffeficient_b = 1.5f;
    public float flSurfaceArea_b = 1.0f;

    private float flDownForce_r = 0.0f;
    private float flDragForce_r = 0.0f;
    private float flCentForce_r = 0.0f;

    

    private WheelFrictionCurve wfcWheelFrictionCurve_v;

    //start functions
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

    void gearSetup()
    {

        
    }

    void wheelFrictionSetup()
    {

        wfcWheelFrictionCurve_v = new WheelFrictionCurve();
        wfcWheelFrictionCurve_v.extremumSlip = 1;
        wfcWheelFrictionCurve_v.extremumValue = 3000;
        wfcWheelFrictionCurve_v.asymptoteSlip = 2;
        wfcWheelFrictionCurve_v.asymptoteValue = 1500;
        wfcWheelFrictionCurve_v.stiffness = 0.091f;

        foreach (WheelCollider w in wheels)
        {
            w.sidewaysFriction = wfcWheelFrictionCurve_v;
            //w.forwardFriction = wfcWheelFrictionCurve_v;
        }

    }
    //update

    void getInputs()
    {
        flThrottle_v = Input.GetAxis("Vertical");
        flSteer_v = Input.GetAxis("Horizontal");
    }


    //fixed update functions

    void complexDrive(Vector3 relativeVel)
    {


        if (blIsPlayer_b)
        {

            

           



        }

    }

    void animateWheels()
    {
        if(blIsPlayer_b){
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
            rotationValue[2] += wheels[2].rpm * (360.0f / 30.0f) * Time.deltaTime;

            
            {
                wheelMesh[6].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
                wheelMesh[7].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
            }
            rotationValue[3] += wheels[3].rpm * (360.0f / 30.0f) * Time.deltaTime;
        }
    }

    void drive()
    {
        flCurrentSpeedL_v = (Mathf.PI * 2 * wheels[2].radius) * wheels[2].rpm * 60/1000;
        //Debug.Log(flCurrentSpeedL_v);

        flCurrentSpeedR_v = (Mathf.PI * 2 * wheels[3].radius) * wheels[3].rpm * 60 / 1000;
        //Debug.Log(flCurrentSpeedR_v);

        if (blIsPlayer_b)
        {
            flTourque_b = Input.GetAxis("Vertical") * Time.deltaTime * flEnginePower_b * 5;
            minSteer = Input.GetAxis("Horizontal") * maxSteer;

            if (Input.GetKey("space"))
            {
                brake = rigidbody.mass * 0.001f;
            }
            else
            {
                brake = 0.0f;
            }

            if (brake > 0.0f)
            {
                wheels[0].brakeTorque = brake * 20;
                wheels[1].brakeTorque = brake *20;
                wheels[2].brakeTorque = brake;
                wheels[3].brakeTorque = brake;
                wheels[2].motorTorque = 0.0f;
                wheels[3].motorTorque = 0.0f;

            }
            else
            {

                wheels[0].brakeTorque = 0.0f;
                wheels[1].brakeTorque = 0.0f;
                wheels[2].brakeTorque = 0.0f;
                wheels[3].brakeTorque = 0.0f;

                if (flCurrentSpeedL_v > flMaxSpeed_b || flCurrentSpeedR_v > flMaxSpeed_b)
                {
                    wheels[2].motorTorque = flTourque_b / 100;
                    wheels[3].motorTorque = flTourque_b / 100;
                }
                else
                {
                    wheels[2].motorTorque = flTourque_b;
                    wheels[3].motorTorque = flTourque_b;
                }
                

            }

            wheels[0].steerAngle = minSteer;
            wheels[1].steerAngle = minSteer;
        }
    }

    void calculateDownForce(Vector3 RelativeVelocity)
    {
        
        //Downforce = 1/2 * Surface Aea * Drag Coefficient * Air Density(1.226) * Speed^2 http://www.ehow.com/how_5128030_calculate-downforce.html
        flDownForce_r = (1.0f / 2.0f) * 1.0f * flDragCoeffeficient_b * (Vector3.Magnitude(RelativeVelocity) * Vector3.Magnitude(RelativeVelocity));
        //Debug.Log(flDownForce_r);
        transform.rigidbody.AddRelativeForce(new Vector3(0, -flDownForce_r, 0));
        
        //transform.rigidbody.AddRelativeForce
    }

    void calculateDragForce(Vector3 RelativeVelocity)
    {

        // Drag force = 1/2 * mass density * velocity^2 * Drag Coefficient * reference area http://en.wikipedia.org/wiki/Drag_equation http://www.ehow.com/how_6149160_calculate-drag.html

        flDragForce_r = (1.0f/ 2.0f) * Vector3.Dot(RelativeVelocity, RelativeVelocity) * flDragCoeffeficient_b * flSurfaceArea_b;
        //Debug.Log(-flDragForce_r);
        
        
        transform.rigidbody.AddRelativeForce(new Vector3(-flDragForce_r, 0, 0));
        //transform.rigidbody.AddForce(Vector3.Normalize(RelativeVelocity)) * flDragForce_r *-1)

    }



    void calculateWheelFriction()
    {

    }

    void Start()
    {

        massSetup();
        gearSetup();
//        wheelfr
        wheelFrictionSetup();

    }

    // Update is called once per frame
    void Update()
    {
        getInputs();
    }

    void FixedUpdate()
    {

        Vector3 relVel =  transform.InverseTransformDirection(rigidbody.velocity);

        Debug.Log(wheels[2].rpm);

        drive();
        calculateDownForce(relVel);
        calculateDragForce(relVel);


        animateWheels();

            


    }


}
