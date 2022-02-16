using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume",volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }
    public void SetFullscreen(bool isFUllscreen)
    {
        Screen.fullScreen = isFUllscreen;
        PlayerPrefs.SetInt("Fullscreen", Convert.ToInt32(isFUllscreen));
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolutionIndex", ResolutionIndex);
        PlayerPrefs.SetInt("Screen_WIDTH", resolution.width);
        PlayerPrefs.SetInt("Screen_HEIGHT", resolution.height);
    }
    public void SetVSync(bool vsync)
    {
        QualitySettings.vSyncCount = Convert.ToInt32(vsync);
        PlayerPrefs.SetInt("Vsync", Convert.ToInt32(vsync));
    }
    public void SetRichPresence(bool dcr)
    {
        PlayerPrefs.SetInt("discordrichpresence", Convert.ToInt32(dcr));
    }
    public void SetCursorLockmode(int lockIndex)
    {
        switch (lockIndex)
        {
            case 0:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case 1:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case 2:
                Cursor.lockState = CursorLockMode.None;
                break;
        }
        PlayerPrefs.SetInt("cursorlockmode", lockIndex);
    }

    public void SaveSettings()
    {
        Debug.Log("Settings Saved");
        PlayerPrefs.Save();
    }
}
