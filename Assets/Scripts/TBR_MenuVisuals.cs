using UnityEngine;
using System.Collections;

public class TBR_MenuVisuals : MonoBehaviour {

    float counter = 0.15f;
    public GameObject[] goVehicle_b;

	// Use this for initialization
	void Start () {
	    //goVehicle_v = GameObject.FindGameObjectsWithTag("AIPath");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.rotation);
        if (TBR_MainMenuController.intMenuButtonSelected_v == 1)
        {
            switch (TBR_MainMenuController.intVehicleSelector_b)
            {
                case 0:
                    transform.rotation = new Quaternion(0.0f, -0.8f, 0.0f, 0.6f);
                    switch (TBR_MainMenuController.intTextureSelector_b)
                    {
                        case 0:
                            foreach (Renderer r in goVehicle_b[0].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("MayDayTex1") as Texture2D);
                            }
                            break;
                        case 1:
                            foreach (Renderer r in goVehicle_b[0].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("MayDayTex2") as Texture2D);
                            }
                            break;
                        case 2:
                            foreach (Renderer r in goVehicle_b[0].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("MayDayTex3") as Texture2D);
                            }
                            break;
                        case 3:
                            foreach (Renderer r in goVehicle_b[0].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("MayDayTex4") as Texture2D);
                            }
                            break;
                    }
                    break;
                case 1:
                    transform.rotation = new Quaternion(0.0f, -0.1f, 0.0f, 1.0f);
                    switch (TBR_MainMenuController.intTextureSelector_b)
                    {
                        case 0:
                            foreach (Renderer r in goVehicle_b[1].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("RichmondTex1") as Texture2D);
                            }
                            break;
                        case 1:
                            foreach (Renderer r in goVehicle_b[1].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("RichmondTex2") as Texture2D);
                            }
                            break;
                        case 2:
                            foreach (Renderer r in goVehicle_b[1].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("RichmondTex3") as Texture2D);
                            }
                            break;
                        case 3:
                            foreach (Renderer r in goVehicle_b[1].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("RichmondTex4") as Texture2D);
                            }
                            break;
                    }
                    break;
                case 2:
                    transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.2f);
                    switch (TBR_MainMenuController.intTextureSelector_b)
                    {
                        case 0:
                            foreach (Renderer r in goVehicle_b[2].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex1") as Texture2D);
                            }
                            break;
                        case 1:
                            foreach (Renderer r in goVehicle_b[2].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex2") as Texture2D);
                            }
                            break;
                        case 2:
                            foreach (Renderer r in goVehicle_b[2].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex3") as Texture2D);
                            }
                            break;
                        case 3:
                            foreach (Renderer r in goVehicle_b[2].GetComponentsInChildren<Renderer>())
                            {
                                r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex4") as Texture2D);
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), counter);
            //counter += 0.2f;
        }
	}
}
