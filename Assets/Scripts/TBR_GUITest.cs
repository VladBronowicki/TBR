using UnityEngine;
using System.Collections;

public class TBR_GUITest : MonoBehaviour {
    
    public int inAmmoCount_b = 0;
	
    
    // Use this for initialization
	void Start () {

        guiText.text = string.Format("{0}", inAmmoCount_b);

	}

    public void vSetCounter_b(int counter)
    {
        guiText.text = string.Format("{0}", counter);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
