using UnityEngine;
using System.Collections;

public class TBR_WaypointController : MonoBehaviour {

    public bool[] blPlayerPassed_b;
    public int tag = -1;

    private GameObject[] goWayPoints_v;


    public int getTag()
    {
        return tag;
    }

	// Use this for initialization
	void Start () {

        //goWayPoints_v = GameObject.FindGameObjectsWithTag("Enemy");

        //blPlayerPassed_b = new bool[goWayPoints_v.Length];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
    
    }

}
