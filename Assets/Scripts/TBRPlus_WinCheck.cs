using UnityEngine;
using System.Collections;

public class TBRPlus_WinCheck : MonoBehaviour {

    public float minHeight = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y < minHeight){
            Application.LoadLevel(0);
        }
	}
}
