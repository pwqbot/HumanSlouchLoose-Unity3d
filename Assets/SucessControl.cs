using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucessControl : MonoBehaviour
{
    public GameObject gameController;
    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<GameController>().sucessGame();
        Debug.Log("sucess");
    }
}
