using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    public void addClips(string ID, string clipLoc)
    {
        try
        {
            Debug.Log($"Loading Clip {clipLoc} assigned to ID: {ID}");
            AudioClip clip = Resources.Load<AudioClip>(clipLoc);
            clips.Add(ID, clip);
        } catch(System.Exception ex) { 
            Debug.Log(ex.ToString());
        }
    }

    public AudioClip getClip(string ID)
    {
        return clips[ID];
    }
}
