using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheck : MonoBehaviour
{
    public int needed;
    public string level;
    public PlayerController player;
    public stateSaving save;
    public GameObject completed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { 
            if(player.Coins >= needed)
            {
                Debug.Log("loading new scene");
                save.setCompletedLevel(level);
                completed.SetActive(true);
            }
        }
    }
}
