using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    AudioMixer audioMixer;

    private float volume;

    void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");

        /*volume = PlayerPrefs.GetFloat("Volume");
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);  
        */
    }
}
