using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text masterTxt, sfxTxt, ambienceTxt;

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        masterTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", MathF.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        sfxTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", MathF.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = Mathf.Clamp((int)(volume * 10), 0, 20);
        ambienceTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbianceVolume", MathF.Log10(volume) * 20);
    }
    private bool isMuted = false;
    public void MuteGame()
    {
        isMuted = !isMuted;
        audioMixer.SetFloat("MasterVolume", isMuted ? -80f : 0f); // -80 dB is effectively silent
    }
}
