using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Deprecated
 * this will be replaced with more versatile utillity classes currently beeing made
 */
public class MapState : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource clip_1;
    public AudioSource clip_2;
    public AudioSource clip_3;

    [Header("Map Controll")]
    public int Mapstate = 0;

    // Sets Mapstate
    public void setMapState(int state) { this.Mapstate = state; }

    // Set AudioClip to current Listener
    public void SetAudioClip(int id)
    {
        // Int 1 - 3 => AudioSource clip_1 - clip_3
        if(id == 1) { clip_1.Play(); } 
        else if (id == 2) { clip_2.Play(); } 
        else if (id == 3) { clip_3.Play(); }
    }

    // Untested should return the specified audioClip
    public AudioClip getAudioClip(string name) { return (AudioClip)this.GetType().GetField(name).GetValue(this); }

    // Returns Mapstate
    public int getMapState() { return Mapstate; }
}
