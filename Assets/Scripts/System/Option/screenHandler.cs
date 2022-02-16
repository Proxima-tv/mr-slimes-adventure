using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenHandler : MonoBehaviour
{
    public GameObject Video;
    public GameObject Audio;
    public GameObject MISC;
    public GameObject Options;
    public GameObject main;

    public void toggleOptions()
    {
        if (Options.activeSelf) {
            Options.SetActive(false);
            if (!main.activeSelf) {  main.SetActive(true); }
        } else {
            if (main.activeSelf)  { main.SetActive(false); }
            Options.SetActive(true);
        }
    }
    public void toggleVideoSettings()
    {
        if (Audio.activeSelf) Audio.SetActive(false);
        if (MISC.activeSelf) MISC.SetActive(false);
        if (!Video.activeSelf) {
            Video.SetActive(true);
        } else {
            return;
        }
    }
    public void toggleAudioSettings()
    {
        if (Video.activeSelf) Video.SetActive(false);
        if (MISC.activeSelf) MISC.SetActive(false);
        if (!Audio.activeSelf) {
            Audio.SetActive(true);
        } else {
            return;
        }
    }
    public void toggleMISCSettings()
    {
        if (Audio.activeSelf) Audio.SetActive(false);
        if (Video.activeSelf) Video.SetActive(false);
        if (!MISC.activeSelf) {
            MISC.SetActive(true);
        } else {
            return;
        }
    }
}
