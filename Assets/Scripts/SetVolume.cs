using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer sfxAudio;
    public AudioMixer musicAudio;

    public void SetsfxLevel(float sliderValue)
    {
        sfxAudio.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicLevel(float sliderValue)
    {
        musicAudio.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
