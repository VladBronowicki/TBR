using UnityEngine;
using System.Collections;

public class TBR_WeaponController : MonoBehaviour {

    public GameObject goGun1_b;
    public GameObject goGun2_b;
    public Rigidbody rbBullet_b;
    public float flFireRate_b = 0.0005f;
    public float flNextFire_b = 0.0f;
    private bool boGun1Active_v;

    public int inAmmoCount_b = 50;
    public int inHealthCount_b = 100;

    private GameObject goTestGameObject_v;

    public GameObject audioObject;

	// Use this for initialization
	void Start () {

        boGun1Active_v = true;
        TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
        tbrGuiTest.vSetCounter_b(inAmmoCount_b);
        audioObject.audio.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > flNextFire_b)
        {
            flNextFire_b = Time.time + flFireRate_b;

            if (inAmmoCount_b > 0)
            {
                if (boGun1Active_v)
                {

                    Rigidbody clone;
                    clone = Instantiate(rbBullet_b, goGun1_b.transform.position, transform.rotation) as Rigidbody;

                    clone.velocity = goGun1_b.transform.forward * 500;
                    boGun1Active_v = false;
                    inAmmoCount_b--;
                }
                else
                {
                    Rigidbody clone;
                    clone = Instantiate(rbBullet_b, goGun2_b.transform.position, transform.rotation) as Rigidbody;

                    clone.velocity = goGun2_b.transform.forward * 500;
                    boGun1Active_v = true;
                    inAmmoCount_b--;
                }
                TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
                tbrGuiTest.vSetCounter_b(inAmmoCount_b);

                audioObject.audio.Play();

            }
        }


	}

    void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.tag == "AmmoCube")
        {
            goTestGameObject_v = collision.gameObject;
            
            //Debug.Log("Hitting");

            inAmmoCount_b += 50;

            TBR_GUITest tbrGuiTest = GameObject.Find("GUI Text").GetComponent("TBR_GUITest") as TBR_GUITest;
            tbrGuiTest.vSetCounter_b(inAmmoCount_b);

            goTestGameObject_v.active = false;
            

        }
        else if (collision.gameObject.tag == "HealthCube")
        {
            if (inHealthCount_b < 100)
            {
                inHealthCount_b += 10;
            }
        }
        else if (collision.gameObject.tag == "SpecialCube")
        {

        }
    }

    IEnumerator ex()
    {
        goTestGameObject_v.active = false;
        yield return new WaitForSeconds(3);
        goTestGameObject_v.active = true;
    }

}
