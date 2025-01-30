using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using TMPro;
using System;

public class F_AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text masterTxt, sfxTxt, ambienceTxt;

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0,20);
        masterTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", MathF.Log10(volume)*20);
        
    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        sfxTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", MathF.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10),0,20);
        ambienceTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbianceVolume", MathF.Log10(volume) * 20);
    }
}
