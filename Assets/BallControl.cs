using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float times = 0;
    private void OnCollisionEnter(Collision other) {
        if(times < 6)
        {
            FindObjectOfType<AudioManager>().Play("Rumble");    
            times++;
        }
    }
}
