using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaySceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(string s) 
    {
        SceneManager.LoadScene(s);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
