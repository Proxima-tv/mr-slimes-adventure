using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    /**
     * Settings created with input of 
     * https://www.red-gate.com/simple-talk/dotnet/c-programming/how-to-create-a-settings-menu-in-unity/
     */
    public void setVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }
    public void setFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
    public void setResolution(int resIndex) {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SaveSettings() {
        PlayerPrefs.SetFloat("VolumePrefs", currentVolume);
        PlayerPrefs.SetInt("FullscreenPrefs", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
    }
    public void LoadSettings(int currentResolutionIndex) {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;
        
        if (PlayerPrefs.HasKey("FullscreenPrefs"))
            Screen.fullScreen =  Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPrefs"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePrefs");
        else
            volumeSlider.value =  PlayerPrefs.GetFloat("VolumePrefs");
    }
}
