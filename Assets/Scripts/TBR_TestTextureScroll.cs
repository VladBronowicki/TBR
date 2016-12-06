using UnityEngine;
using System.Collections;

public class TBR_TestTextureScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
        float offset = Time.time * 0.5f;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, -0.1f));
        //renderer.material.SetTextureOffset("Arrow",new Vector2(offset, 0.0f));

	}
}
