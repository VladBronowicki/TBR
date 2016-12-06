using UnityEngine;
using System.Collections;

public class TBR_VehicleWaypointController : MonoBehaviour {

    private GameObject[] goWaypoints_v;
    public bool[] blWaypointCheck_b;
    public int intLapCounter_b;
    


	// Use this for initialization
	void Start () {

        goWaypoints_v = GameObject.FindGameObjectsWithTag("Waypoint");

        blWaypointCheck_b = new bool[goWaypoints_v.Length];

        for(int i = 0; i < blWaypointCheck_b.Length -1; ++i)
        {

            blWaypointCheck_b[i] = true;

        }
        blWaypointCheck_b[blWaypointCheck_b.Length - 1] = false;
        
        intLapCounter_b = 0;

	}
	
	// Update is called once per frame
	void Update () {

	}

    void LateUpdate()
    {

        bool allTrue = true;
        for (int i = 0; i < blWaypointCheck_b.Length; ++i)
        {
            if (blWaypointCheck_b[i] == false)
            {
                allTrue = false;
                break;
            }
        }

        if (allTrue)
        {
            for (int i = 0; i < blWaypointCheck_b.Length; ++i)
            {
                blWaypointCheck_b[i] = false;
            }
            intLapCounter_b += 1;
        }
    }

    void OnTriggerExit(Collider col)
    {

        for (int i = 0; i < goWaypoints_v.Length; ++i)
        {

            if ((col.tag == "Waypoint" && col == goWaypoints_v[i].collider) && (goWaypoints_v[i].transform.GetComponent<TBR_WaypointController>().getTag() == 0))
            {
                blWaypointCheck_b[goWaypoints_v[i].transform.GetComponent<TBR_WaypointController>().getTag()] = true;
            }

            if ((col.tag == "Waypoint" && col == goWaypoints_v[i].collider) && (goWaypoints_v[i].transform.GetComponent<TBR_WaypointController>().getTag() != 0))
            {

                if (blWaypointCheck_b[goWaypoints_v[i].transform.GetComponent<TBR_WaypointController>().getTag() - 1] == true)
                {

                    blWaypointCheck_b[goWaypoints_v[i].transform.GetComponent<TBR_WaypointController>().getTag()] = true;

                }
            }
        }
    }

}
