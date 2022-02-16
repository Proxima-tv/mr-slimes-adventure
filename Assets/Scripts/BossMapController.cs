using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMapController : MonoBehaviour
{
    public PlayerController player;
    public GameObject wall;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Coins: " + player.Coins);
        if(player.Coins >= 3)
        {
            Destroy(wall);
        }        
    }
}
