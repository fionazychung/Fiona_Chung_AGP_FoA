using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        Play("MX_1");
        //Debug.Log("Played");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void ButtonClick()
    {
        Play("SFX_Click_1");
        /*int click = 
        if (click == 0)
        {
            Play("SFX_Click_1");
        }
        else
        {
            Play("SFX_Click_2");
        }*/
    }
}
