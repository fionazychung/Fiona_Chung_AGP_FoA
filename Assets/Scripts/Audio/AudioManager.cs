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

    public Sound[] buttonClickArray;
    private int buttonClickIndex;
    private int[] previousButtonClickArray;
    private int previousButtonClickArrayIndex;

    public Sound[] pickCardArray;
    private int pickCardIndex;
    private int[] previousPickArray;
    private int previousPickArrayIndex;

    public Sound[] placeCardArray;
    private int placeCardIndex;
    private int[] previousArray;
    private int previousArrayIndex;


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
            s.source.outputAudioMixerGroup = s.mixer;
            //s.source.pitch = s.pitch;
        }

        foreach (Sound s in buttonClickArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
        foreach (Sound s in pickCardArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
        foreach (Sound s in placeCardArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        PlaySounds("MX_1");
        //Debug.Log("Played");

    }

    public void PlaySounds (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    /*public void PlayButtonClick (string name)
    {
        Sound s = Array.Find(placeCardArray, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void ButtonClick()
    {
        int click = UnityEngine.Random.Range(0, 2);
        if (click == 0)
        {
            PlaySounds("SFX_Click_1");
        }
        else
        {
            PlaySounds("SFX_Click_2");
        }
    }*/

    public Sound GetRandomButtonClickSound()
    {

        if (previousButtonClickArray == null)
        {
            // Sets the length to half of the number of AudioClips
            // This will round downwards
            // So it works with odd numbers like for example 3
            previousButtonClickArray = new int[buttonClickArray.Length / 2];
        }
        if (previousButtonClickArray.Length == 0)
        {
            // If the the array length is 0 it returns null
            return null;
        }
        else
        {
            // Psuedo random remembering previous clips to avoid repetition
            do
            {
                buttonClickIndex = UnityEngine.Random.Range(0, buttonClickArray.Length);
            } while (PreviousButtonClickArrayContainsSoundIndex());
            // Adds the selected array index to the array
            previousButtonClickArray[previousButtonClickArrayIndex] = buttonClickIndex;
            // Wrap the index
            previousButtonClickArrayIndex++;
            if (previousButtonClickArrayIndex >= previousButtonClickArray.Length)
            {
                previousButtonClickArrayIndex = 0;
            }
        }

        Sound s = buttonClickArray[buttonClickIndex];
        s.source.Play();
        // Returns the randomly selected clip
        return buttonClickArray[buttonClickIndex];

    }

    // Returns if the randomIndex is in the array
    private bool PreviousButtonClickArrayContainsSoundIndex()
    {
        for (int i = 0; i < previousButtonClickArray.Length; i++)
        {
            if (previousButtonClickArray[i] == buttonClickIndex)
            {
                return true;
            }
        }
        return false;
    }


    public Sound GetRandomPickCardSound()
    {

        if (previousPickArray == null)
        {
            // Sets the length to half of the number of AudioClips
            // This will round downwards
            // So it works with odd numbers like for example 3
            previousPickArray = new int[pickCardArray.Length / 2];
        }
        if (previousPickArray.Length == 0)
        {
            // If the the array length is 0 it returns null
            return null;
        }
        else
        {
            // Psuedo random remembering previous clips to avoid repetition
            do
            {
                pickCardIndex = UnityEngine.Random.Range(0, pickCardArray.Length);
            } while (PreviousPickArrayContainsSoundIndex());
            // Adds the selected array index to the array
            previousPickArray[previousPickArrayIndex] = pickCardIndex;
            // Wrap the index
            previousPickArrayIndex++;
            if (previousPickArrayIndex >= previousPickArray.Length)
            {
                previousPickArrayIndex = 0;
            }
        }

        Sound s = pickCardArray[pickCardIndex];
        s.source.Play();
        // Returns the randomly selected clip
        return pickCardArray[placeCardIndex];

    }

    // Returns if the randomIndex is in the array
    private bool PreviousPickArrayContainsSoundIndex()
    {
        for (int i = 0; i < previousPickArray.Length; i++)
        {
            if (previousPickArray[i] == pickCardIndex)
            {
                return true;
            }
        }
        return false;
    }


    public Sound GetRandomPlaceCardSound()
    {
        
        if (previousArray == null)
        {
            // Sets the length to half of the number of AudioClips
            // This will round downwards
            // So it works with odd numbers like for example 3
            previousArray = new int[placeCardArray.Length / 2];
        }
        if (previousArray.Length == 0)
        {
            // If the the array length is 0 it returns null
            return null;
        }
        else
        {
            // Psuedo random remembering previous clips to avoid repetition
            do
            {
                    placeCardIndex = UnityEngine.Random.Range(0, placeCardArray.Length);
            } while (PreviousArrayContainsSoundIndex());
            // Adds the selected array index to the array
            previousArray[previousArrayIndex] = placeCardIndex;
            // Wrap the index
            previousArrayIndex++;
            if (previousArrayIndex >= previousArray.Length)
            {
                previousArrayIndex = 0;
            }
        }

        Sound s = placeCardArray[placeCardIndex];
        s.source.Play();
        // Returns the randomly selected clip
        return placeCardArray[placeCardIndex];

    }

    // Returns if the randomIndex is in the array
    private bool PreviousArrayContainsSoundIndex()
    {
        for (int i = 0; i < previousArray.Length; i++)
        {
            if (previousArray[i] == placeCardIndex)
            {
                return true;
            }
        }
        return false;
    }
}


