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
        soundManager.addClips("Jump", "Audio/Jump");
        soundManager.addClips("Track01", "Audio/Music/adhesivewombat");
        soundManager.addClips("Track02", "Audio/Music/All Time High Jump - 8 BitChiptune - Royalty Free Music");
        soundManager.playInMap("Track01", 0);
    }

    public void setMapState()
    {

    }
}
