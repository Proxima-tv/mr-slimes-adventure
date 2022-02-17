using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionLoader: MonoBehaviour
{
    // References for settings asignment
    public AudioMixer audioMixer;
    public Dropdown ResolutionDropDown;
    public Dropdown QualityDropdown;
    public Dropdown CursorLockModeDropdown;
    public Toggle VSYNCToggle;
    public Toggle FullscreenToggle;
    public Toggle DCRichPresence;
    public Slider VolumeSlider;

    // Settings the Player Settings
    void Start()
    {
        // Asignments from PlayerPrefs
        float Volume = PlayerPrefs.GetFloat("MasterVolume");
        int Quality = PlayerPrefs.GetInt("Quality");
        bool Fullscreen = Convert.ToBoolean(PlayerPrefs.GetInt("Fullscreen"));
        bool discordRichPresence = Convert.ToBoolean(PlayerPrefs.GetInt("discordrichpresence"));
        int Screen_WIDTH = PlayerPrefs.GetInt("Screen_WIDTH");
        int Screen_HEIGHT = PlayerPrefs.GetInt("Screen_HEIGHT");
        int VSYNC = PlayerPrefs.GetInt("Vsync");
        int CursorLockmodeValue = PlayerPrefs.GetInt("cursorlockmode");

        Debug.Log("Volume: " + Volume);
        Debug.Log("Quality: " + Quality);
        Debug.Log("Fullscreen: " + Fullscreen);
        Debug.Log("Width: " + Screen_WIDTH);
        Debug.Log("Height: " + Screen_HEIGHT);
        Debug.Log("VSync: " + VSYNC);
        Debug.Log("CursorMode: " + CursorLockmodeValue);
        Debug.Log("Discord Richpresence: " + discordRichPresence);

        ResolutionDropDown.value = PlayerPrefs.GetInt("resolutionIndex");
        QualityDropdown.value = Quality;
        CursorLockModeDropdown.value = CursorLockmodeValue;
        VSYNCToggle.isOn = Convert.ToBoolean(VSYNC);
        FullscreenToggle.isOn = Convert.ToBoolean(Fullscreen);
        DCRichPresence.isOn = discordRichPresence;
        VolumeSlider.value = Volume;

        ResolutionDropDown.RefreshShownValue();
        QualityDropdown.RefreshShownValue();
        CursorLockModeDropdown.RefreshShownValue();

        audioMixer.SetFloat("MasterVolume", Volume);
        QualitySettings.SetQualityLevel(Quality);
        Screen.fullScreen = Fullscreen;
        Screen.SetResolution(Screen_WIDTH, Screen_HEIGHT, Screen.fullScreen);
        QualitySettings.vSyncCount = VSYNC;

        Cursor.lockState = CursorLockMode.None;
        switch (CursorLockmodeValue)
        {
            case 0: Cursor.lockState = CursorLockMode.Locked; break;
            case 1: Cursor.lockState = CursorLockMode.Confined; break;
            case 2: Cursor.lockState = CursorLockMode.None; break;
        }
    }
}
