using UnityEngine;
using System.Collections;

public class TBRPlus_CannonController : MonoBehaviour
{

    public float rotSpeed = 10;
    public float maxRotation = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F))
        { //'Rotates' the barrel down.
            if (maxRotation > 0)
            { //Prevents the rotation beyond the height of the turret.
                transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
                maxRotation -= rotSpeed * Time.deltaTime;
                
            }
        }

        if (Input.GetKey(KeyCode.R))
        {  //'Rotates' the barrel up.       
            if (maxRotation < 25)
            { //Prevents rotate beyong the top of the turret to look more realistic
                transform.Rotate(0, -rotSpeed * Time.deltaTime, 0);
                maxRotation += rotSpeed * Time.deltaTime;
            }
        }
    }
}
