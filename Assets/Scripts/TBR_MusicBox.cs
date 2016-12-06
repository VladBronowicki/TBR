using UnityEngine;
using System.Collections;

public class TBR_MusicBox : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        if (TBR_MainMenuController.intMusicToggle_b == 0)
        {
            
            if (!transform.audio.isPlaying)
            {
                transform.audio.Play();
            }
        }
        if (TBR_MainMenuController.intMusicToggle_b == 1)
        {
            transform.audio.Pause();
            
        }

    }
    void Awake()
    {

            DontDestroyOnLoad(transform.gameObject);


    }
}