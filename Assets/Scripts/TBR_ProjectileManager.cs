using UnityEngine;
using System.Collections;

public class TBR_ProjectileManager : MonoBehaviour {
    private float creationtime = 0.0f;
    public GameObject audioObject;
    public bool blDestroysOnCol_v = true;
    //public Transform explosionPrefab;
	// Use this for initialization
	void Start () {
        creationtime = Time.time;
        audioObject.audio.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	 if (Time.time > (creationtime + 10))
        {
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        //audioObject.audio.
        
        audioObject.audio.Play();
        audioObject.audio.maxDistance = 10000;
        audioObject.audio.minDistance = 25;
        if (blDestroysOnCol_v)
        {
            Destroy(gameObject);
        }
    }
}
