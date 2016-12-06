using UnityEngine;
using System.Collections;




public class PlayerController : MonoBehaviour {

    //float acceleration;
	public WheelCollider[] wheels;
    public GameObject[] wheelMesh;
    public Transform coMass;


    
    public float ePower = 0.0f;
    public float maxEPower = 150.0f;
    public float brake = 0.0f;
    public float minSteer = 0.0f;
    public float maxSteer = 25.0f;
    private float[] rotationValue = new float[4];
    // Use this for initialization
	void Start () {

        if (coMass)
        {
            rigidbody.centerOfMass = coMass.localPosition; 
            wheelMesh[0].transform.Rotate(90.0f,0.0f,90.0f);
            wheelMesh[1].transform.Rotate(90.0f, 0.0f, 90.0f);

        }
	}
	
	// Update is called once per frame
	void Update () {

        ePower = Input.GetAxis("Vertical") * Time.deltaTime * 2500.0f;
        minSteer = Input.GetAxis("Horizontal") * maxSteer;

        if (Input.GetKey("space"))
        {
            brake = rigidbody.mass * 0.1f;
        }
        else
        {
            brake = 0.0f;
        }

        if (brake > 0.0f)
        {
            wheels[0].brakeTorque = brake;
            wheels[1].brakeTorque = brake;
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
            wheels[2].motorTorque = ePower;
            wheels[3].motorTorque = ePower;
            animateWheels();

        }

        wheels[0].steerAngle = minSteer;
        wheels[1].steerAngle = minSteer;

        wheelMesh[0].transform.rotation = wheels[0].transform.rotation * Quaternion.Euler(0, wheels[0].steerAngle - 90.0f, -rotationValue[0]);
        wheelMesh[1].transform.rotation = wheels[0].transform.rotation * Quaternion.Euler(0, wheels[0].steerAngle - 90.0f, -rotationValue[0]);
        rotationValue[0] += wheels[0].rpm * (360.0f / 60.0f) * Time.deltaTime;

        wheelMesh[2].transform.rotation = wheels[1].transform.rotation * Quaternion.Euler(0, wheels[1].steerAngle + 90.0f, rotationValue[1]);
        wheelMesh[3].transform.rotation = wheels[1].transform.rotation * Quaternion.Euler(0, wheels[1].steerAngle + 90.0f, rotationValue[1]);
        rotationValue[1] += wheels[1].rpm * (360.0f / 60.0f) * Time.deltaTime;

        wheelMesh[4].transform.rotation = wheels[2].transform.rotation * Quaternion.Euler(0, wheels[2].steerAngle - 90.0f, -rotationValue[2]);
        wheelMesh[5].transform.rotation = wheels[2].transform.rotation * Quaternion.Euler(0, wheels[2].steerAngle - 90.0f, -rotationValue[2]);
        rotationValue[2] += wheels[2].rpm * (360.0f / 60.0f) * Time.deltaTime;

        wheelMesh[6].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
        wheelMesh[7].transform.rotation = wheels[3].transform.rotation * Quaternion.Euler(0, wheels[3].steerAngle + 90.0f, rotationValue[3]);
        rotationValue[3] += wheels[3].rpm * (360.0f / 60.0f) * Time.deltaTime;
        
	}

    void FixedUpdate()
    {


        
    }

    void setupWheels()
    {



    }

    void animateWheels()
    {
        foreach (GameObject wm in wheelMesh)
        {
            //wm.transform.Rotate(0.0f, 0.0f, 1.0f);
        }
    }

}
