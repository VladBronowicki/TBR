using UnityEngine;
using System.Collections;

public class TBR_MMCameraController : MonoBehaviour {

    private float flUpDown_v = 0.0f;
    private float flLeftRight_v = 0.0f;
    private float flZoom_v = 0.0f;
    private bool blClicked = false;

    public int intMoveSpeed_b = 5;
    public float flMinZoom_b = 10.0f;
    public float flMaxZoom_b = 80.0f;

    public GameObject test;

    void getInputs()
    {
        flLeftRight_v = Input.GetAxis("Vertical");
        flUpDown_v = Input.GetAxis("Horizontal");
        flZoom_v = Input.GetAxis("Mouse ScrollWheel");
        blClicked = Input.GetButtonDown("Fire1");

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        getInputs();
        transform.Translate(flUpDown_v * intMoveSpeed_b, flLeftRight_v * intMoveSpeed_b, 0.0f);

        if (((transform.camera.fieldOfView > flMinZoom_b) && (flZoom_v > 0)) || ((transform.camera.fieldOfView < flMaxZoom_b)) && (flZoom_v < 0))
        {
            transform.camera.fieldOfView = transform.camera.fieldOfView + (-flZoom_v * intMoveSpeed_b)*2;
        }
        if (blClicked)
        {
            Ray ray = transform.camera.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.origin;
            if (Physics.Raycast(ray))
            {
                GameObject instance = (GameObject)Instantiate(Resources.Load("MapMakerStrait"),new Vector3(point.x, 2.5f,point.z),Quaternion.identity);
            }
        }

        
        
	}
}
