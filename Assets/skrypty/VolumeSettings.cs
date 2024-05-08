using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider Mainslider;
    [SerializeField] private Slider Musiclider;
    [SerializeField] private Slider SFXslider;
    public void SetMainVolume()
    {
        float volume = Mainslider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("mainvolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = Musiclider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicvolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXslider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXvolume", volume);
    }

    private void LoadVolume()
    {
        Mainslider.value = PlayerPrefs.GetFloat("mainvolume");
        Musiclider.value = PlayerPrefs.GetFloat("musicvolume");
        SFXslider.value = PlayerPrefs.GetFloat("SFXvolume");
        SetMainVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("mainvolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMainVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    void Update()
    {

    }
}