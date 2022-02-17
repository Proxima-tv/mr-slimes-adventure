using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StateManager stateManager;
    private SoundManager soundManager;

    void Start()
    {
        Debug.Log("Loading Manager Instances");
        Debug.Log($"Loading StateManager");
        stateManager = GetComponent<StateManager>();
        Debug.Log($"Loading SoundManager");
        soundManager = GetComponent<SoundManager>();
        Debug.Log("Registering Gamestates for the level");
        stateManager.addState("running");
        stateManager.addState("paused");
        stateManager.addState("boss");
        Debug.Log("Loading Audio Assets");
        soundManager.addClips("test", "Audio/Music/adhesivewombat");
        Debug.Log(soundManager.getClip("test"));
    }

    public void setMapState()
    {

    }
}
