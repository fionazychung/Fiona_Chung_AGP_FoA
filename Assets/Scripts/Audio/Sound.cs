using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    public bool loop;
    [Range(0f, 1f)]
    public float volume;
    //[Range(.1f, 3f)]
    private float pitch = 1f;
    public AudioMixerGroup mixer;

    //output mixer 

    [HideInInspector]
    public AudioSource source;
}
