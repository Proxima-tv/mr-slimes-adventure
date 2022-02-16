using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateSaving : MonoBehaviour
{
    public void setLive(int live)
    {
        PlayerPrefs.SetInt("live", live);
        PlayerPrefs.Save();
    }

    public void setCompletedLevel(string level)
    {
        PlayerPrefs.SetString("level", level);
        PlayerPrefs.Save();
    }
}
