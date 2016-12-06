using UnityEngine;
using System.Collections;

public class TBR_LapManager : MonoBehaviour {

    private GameObject[] goWaypoints_v;
    private GameObject[] goPlayers_v;
    public bool[] blWaypointCheck_b;

	// Use this for initialization
	void Start () {

        goWaypoints_v = GameObject.FindGameObjectsWithTag("Waypoint");

        blWaypointCheck_b = new bool[goWaypoints_v.Length];


	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < goWaypoints_v.Length; ++i)
        {

            //if(

        }


	}

    void OnTriggerStay(Collider col)
    {


    }

}
