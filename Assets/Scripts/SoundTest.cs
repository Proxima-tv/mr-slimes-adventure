using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public SoundManager soundManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player entered point");
            soundManager.playInMap("Track02", 0);
            Destroy(this.gameObject);
        }
    }
}
