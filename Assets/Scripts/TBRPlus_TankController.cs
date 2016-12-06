using UnityEngine;
using System.Collections;

public class TBRPlus_TankController : MonoBehaviour {

    public GameObject goTankTurret_b;
    public GameObject goTankCannon_b;
    public GameObject goTankCannon2_b;
    public GameObject goTankPivotPoint_b;

    public GameObject goTankTurretPivot_b;
    public GameObject goTankLauncher_b;

    private float flRotationLockX_v = 0;
    public int inAmmoCount_b = 5;
    public float flNextFire_b = 0.0f;
    public float flFireRate_b = 0.0005f;
    public Rigidbody rbBullet_b;


    public GameObject audioObject;

	// Use this for initialization
	void Start () {
        TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
        tbrGuiTest.vSetCounter_b(inAmmoCount_b);

        audioObject.audio.enabled = true;
	}

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "AmmoCube")
        {
            GameObject goTestGameObject_v = collision.gameObject;

            //Debug.Log("Hitting");

            inAmmoCount_b += 5;

            TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
            tbrGuiTest.vSetCounter_b(inAmmoCount_b);

            goTestGameObject_v.active = false;


        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey("q"))
        {
            goTankCannon_b.transform.RotateAround(goTankPivotPoint_b.transform.position,Vector3.up, -0.45f);
            goTankCannon2_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, -0.45f);
            goTankTurret_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, -0.45f);
            //goTankLauncher_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, -0.45f);
            goTankTurretPivot_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, -0.45f);
           
        }
        if (Input.GetKey("e"))
        {
            goTankCannon_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, 0.45f);
            goTankCannon2_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, 0.45f);
            goTankTurret_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, 0.45f);
            //goTankLauncher_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, 0.45f);
            goTankTurretPivot_b.transform.RotateAround(goTankPivotPoint_b.transform.position, Vector3.up, 0.45f);
        }

        /*if (Input.GetKey("r"))
        {
            //dsif (flRotationLockX_v > -15.0f)
            {
                goTankCannon_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), -0.45f);
                goTankCannon2_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), -0.45f);
                goTankLauncher_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), -0.45f);

                flRotationLockX_v -= .45f;

            }
        }
        if (Input.GetKey("f"))
        {
            //if (flRotationLockX_v < 7.5f)
            {
                goTankCannon_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), 0.45f);
                goTankCannon2_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), 0.45f);
                goTankLauncher_b.transform.RotateAround(goTankTurretPivot_b.transform.position, new Vector3(1.0f, 0.0f, 0.0f), 0.45f);

                flRotationLockX_v += .45f;

            }
        }*/
        if (Input.GetButton("Fire1") && Time.time > flNextFire_b)
        {
            flNextFire_b = Time.time + flFireRate_b;

            if (inAmmoCount_b > 0)
            {
                Rigidbody clone;
                clone = Instantiate(rbBullet_b, goTankLauncher_b.transform.position, transform.rotation) as Rigidbody;
                clone.rotation = goTankLauncher_b.transform.rotation;
                clone.velocity = goTankLauncher_b.transform.forward * 150;
                
                inAmmoCount_b--;

                TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
                tbrGuiTest.vSetCounter_b(inAmmoCount_b);
                audioObject.audio.Play();
                audioObject.audio.maxDistance = 1000;
                audioObject.audio.minDistance = 25;
            }

        }


	}
}
