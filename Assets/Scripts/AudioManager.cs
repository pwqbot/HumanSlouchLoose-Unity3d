using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public Sound[] sounds;
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.audioSource.Play();
    }
    private void Awake() {


        // if(audioManager == null)
        //     audioManager = this;
        // else 
        //     Destroy(gameObject);

        // DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.Volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }    
        if(SceneManager.GetActiveScene().name == "SpinCrazy")
            Play("Amelie");
        else if(SceneManager.GetActiveScene().name == "KinderGarden")
            Play("SUFJAN");
        else if(SceneManager.GetActiveScene().name == "Mathematician")
            Play("RIOPY");
        
    }
 
    // Update is called once per frame
}
