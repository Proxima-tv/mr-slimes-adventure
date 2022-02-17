using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private Dictionary<string, AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        clips = new Dictionary<string, AudioClip>();
    }

    public void addClips(string title, AudioClip clip)
    {
        Debug.Log("Loading Audio Clip: " + title);
        clips.Add(title, clip);
    }

    public AudioClip getClip(string title)
    {
        return clips[title];
    }
}
