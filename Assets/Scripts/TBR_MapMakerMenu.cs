using UnityEngine;
using System.Collections;

public class TBR_MapMakerMenu : MonoBehaviour {

    private int trackSelector = 0;
    public int intTrackSelected_b = 0;
    private string[] trackSelectorString = new string[] { "Strait", "Bend", "Intersection" };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        intTrackSelected_b = GUI.SelectionGrid(new Rect(25, 25, 300, 75), intTrackSelected_b, trackSelectorString, 3);

        if (GUI.Button(new Rect(25, 110, 100, 75), "Save"))
        {
        }

        if (GUI.Button(new Rect(25, 195, 100, 75), "Load"))
        {
        }
    }

}
