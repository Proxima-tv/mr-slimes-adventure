using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public PlayerController player;
    private void OnCollisionEnter(Collision collision)
    {
        player.Coins = player.Coins + 1;
        player.coins.text = "Coins: " + player.Coins.ToString();
    }
}
