using UnityEngine;
using System.Collections;

public class TBR_LevelManager : MonoBehaviour {

    //public int inVehicleSelector_b = TBR_MainMenuController.intVehicleSelector_b;
    public GameObject goStartPoint_b;
    public Camera camMainCam_b;

    private bool isPaused_v = false;
    
    
    //public GameObject[] goVehicleArray_b;
	// Use this for initialization
	void Start () {
        //Debug.Log(TBR_MainMenuController.intVehicleSelector_b);
        int carVal = TBR_MainMenuController.intVehicleSelector_b;
        int texVal = TBR_MainMenuController.intTextureSelector_b;
        int raceVal = TBR_MainMenuController.intModeSelect_b;



        //GameObject cam = GameObject.FindGameObjectWithTag("Camera");
        GameObject localPlayerVehicle;
        //
        //= (GameObject)Instantiate(goVehicleArray_b[TBR_MainMenuController.intVehicleSelector_b]);
        Renderer[] tempR;
        switch (carVal)
        {
            case 0:
                localPlayerVehicle = (GameObject)Instantiate(Resources.Load("TBRMayday"));
                localPlayerVehicle.transform.position = goStartPoint_b.transform.position;
                //camMainCam_b.GetComponent<SmoothFollow>().target = (Transform)localPlayerVehicle.GetComponent("CenterOfMass");
                switch (texVal)
                {
                    case 0:

                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("MayDayTex1") as Texture2D);
                        }
                        break;
                    case 1:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("MayDayTex2") as Texture2D);
                        }
                        break;
                    case 2:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("MayDayTex3") as Texture2D);
                        }
                        break;
                    case 3:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("MayDayTex4") as Texture2D);
                        }
                        break;

                }

                localPlayerVehicle.GetComponent<TBR_VehicleControllerMKII>().blIsPlayer_b = true;
                //localPlayerVehicle
                //camMainCam_b.GetComponent<SmoothFollow>().target = (Transform)localPlayerVehicle.GetComponent("CenterOfMass");
                break;
            case 1:
                localPlayerVehicle = (GameObject)Instantiate(Resources.Load("TBRRichmond"));
                localPlayerVehicle.transform.position = goStartPoint_b.transform.position;
                switch (texVal)
                {
                    case 0:

                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("RichmondTex1") as Texture2D);
                        }
                        break;
                    case 1:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("RichmondTex2") as Texture2D);
                        }
                        break;
                    case 2:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("RichmondTex3") as Texture2D);
                        }
                        break;
                    case 3:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("RichmondTex4") as Texture2D);
                        }
                        break;

                }
                localPlayerVehicle.GetComponent<TBR_VehicleControllerMKII>().blIsPlayer_b = true;
                //cam.GetComponent<SmoothFollow>().target = (Transform)localPlayerVehicle.GetComponent("CenterOfMass");
                break;
            case 2:
                localPlayerVehicle = (GameObject)Instantiate(Resources.Load("TBRClarkson"));
                localPlayerVehicle.transform.position = goStartPoint_b.transform.position;
                switch (texVal)
                {
                    case 0:

                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex1") as Texture2D);
                        }
                        break;
                    case 1:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex2") as Texture2D);
                        }
                        break;
                    case 2:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex3") as Texture2D);
                        }
                        break;
                    case 3:
                        tempR = localPlayerVehicle.GetComponentsInChildren<Renderer>();
                        foreach (Renderer r in tempR)
                        {
                            r.material.SetTexture("_MainTex", Resources.Load("ClarksonTex4") as Texture2D);
                        }
                        break;
                }
                localPlayerVehicle.GetComponent<TBR_VehicleControllerMKII>().blIsPlayer_b = true;
                break;



        }
        switch (raceVal)
        {

            case 0:
                break;
            case 1:
                loadAI();
                GameObject race = (GameObject)Instantiate(Resources.Load("Races/TestRace1"));
                //goStartPoint_b = 
                break;



        }

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(KeyCode.Escape)){
            if (!isPaused_v)
            {
                isPaused_v = true;
                Time.timeScale = 0.0f;
            }
            else if (isPaused_v)
            {
                isPaused_v = false;
                Time.timeScale = 1.0f;
            }
        }
	}

    void OnGUI()
    {

        if (isPaused_v)
        {
            if (GUI.Button(new Rect(10, 10, 100, 50), "Resume"))
            {
                Time.timeScale = 1.0f;
                isPaused_v = false;
            }
            if (GUI.Button(new Rect(10, 70, 100, 50), "Main Menu"))
            {
                Time.timeScale = 1.0f;
                //print("You clicked the button!");
                Application.LoadLevel(0);
                

            }
            if (GUI.Button(new Rect(10, 130, 100, 50), "Exit"))
            {
                //print("You clicked the button!");
                Application.Quit();

            }

        }

    }


    void loadAI()
    {
        GameObject temp1 = (GameObject)Instantiate(Resources.Load("TBRClarkson"));
        temp1.transform.position = goStartPoint_b.transform.position + new Vector3(0.0f, 0.0f, 6.0f);
        //temp1.transform.RotateAround(temp1.transform.position, Vector3.up, 180.0f);
        temp1.GetComponent<TBR_VehicleControllerMKII>().blIsAI_b = true;

        GameObject temp2 = (GameObject)Instantiate(Resources.Load("TBRRichmond"));
        temp2.transform.position = goStartPoint_b.transform.position + new Vector3(10.0f, 0.0f, 6.0f);
        //temp2.transform.RotateAround(temp1.transform.position, Vector3.up, 180.0f);
        temp2.GetComponent<TBR_VehicleControllerMKII>().blIsAI_b = true;

        Renderer[] tempR2;
        tempR2 = temp2.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in tempR2)
        {
            r.material.SetTexture("_MainTex", Resources.Load("RichmondTex2") as Texture2D);
        }

        GameObject temp3 = (GameObject)Instantiate(Resources.Load("TBRMayDay"));
        temp3.transform.position = goStartPoint_b.transform.position + new Vector3(10.0f, 0.0f, 0.0f);
        temp3.GetComponent<TBR_VehicleControllerMKII>().blIsAI_b = true;/**/
    }
}
