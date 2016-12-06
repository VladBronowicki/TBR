using UnityEngine;
using System.Collections;

public class TBRPlus_WallTime : MonoBehaviour {

    private float wallTime_v;

	// Use this for initialization
	void Start () {
        //wallTime_v = 300;
	}
	
	// Update is called once per frame
	void Update () {
        wallTime_v = 300.0f - Time.timeSinceLevelLoad;
        guiText.text = string.Format("{0}", wallTime_v);
        if (wallTime_v < 0.0f)
        {
            Application.LoadLevel(0);
        }

	}
}
