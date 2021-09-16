using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    public GameObject character;
    private bool flag = true;    

    public void Switch()
    {
        g1.active = flag;
        g2.active = !flag;
        flag = !flag;
        GameController.rotate = !GameController.rotate;
    }
}
