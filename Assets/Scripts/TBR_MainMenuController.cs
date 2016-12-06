using UnityEngine;
using System.Collections;

public class TBR_MainMenuController : MonoBehaviour {

    public static int intMenuButtonSelected_v = 0;
    public static int intVehicleSelector_b = 0;
    private string[] strVehicle_v = new string[] { "Mayday", "Richmond", "Clarkson" };
    public static int intTextureSelector_b = 0;
    private string[] strTexture_v = new string[] { "Texture 1", "Texture 2", "Texture 3", "Texture 4" };
    public int intLevelSelector_b = 0;
    private string[] strLevel_v = new string[] { "Toybox City"};
    public static int intMusicToggle_b = 0;
    private string[] strMusicOnOff_v = new string[] { "Music On", "Music Off" };
    public static int intModeSelect_b = 0;
    private string[] strModeSelect_v = new string[] { "Open World", "Level 1"};


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Play"))
        {

            intMenuButtonSelected_v = 1;

        }

        if (GUI.Button(new Rect(10, 70, 100, 50), "Options"))
        {

            intMenuButtonSelected_v = 2;

        }

        if (GUI.Button(new Rect(10, 130, 100, 50), "Instructions"))
        {
            //print("You clicked the button!");
            intMenuButtonSelected_v = 3;

        }

        if (GUI.Button(new Rect(10, 190, 100, 50), "exit"))
        {
            //print("You clicked the button!");
            Application.Quit();

        }
        if (intMenuButtonSelected_v == 1)
        {

            intVehicleSelector_b = GUI.SelectionGrid(new Rect(130, 10, 200, 75), intVehicleSelector_b, strVehicle_v, 2);
            intTextureSelector_b = GUI.SelectionGrid(new Rect(130, 90, 200, 100), intTextureSelector_b, strTexture_v, 2);
            intLevelSelector_b = GUI.SelectionGrid(new Rect(130, 195, 200, 75), intLevelSelector_b, strLevel_v, 2);
            intModeSelect_b = GUI.SelectionGrid(new Rect(130, 275, 200, 75), intModeSelect_b, strModeSelect_v, 1);
            //Debug.Log(intVehicleSelector_b);
            if (GUI.Button(new Rect(130, 355, 200, 50), "START!"))
            {
                Application.LoadLevel(intLevelSelector_b + 1);
            }

        }
        else if (intMenuButtonSelected_v == 2)
        {
            intMusicToggle_b = GUI.SelectionGrid(new Rect(130, 10, 200, 75), intMusicToggle_b, strMusicOnOff_v, 2);
            //Debug.Log(intMusicToggle_b);
        }
        else if (intMenuButtonSelected_v == 3)
        {

            GUI.Label(new Rect(130, 10, 500, 200), "Movement Controls:\nW - Forward\nS - Reverse\nA & D - Steer\nMouse - Move Camera", "box");

        }

    }

}
