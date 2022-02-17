using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int health;
    public Object[] Inventar;
    public int[] CompleteLevel;

    public PlayerData(PlayerController player)
    {
        coins = player.Coins;
        health = player.life;
        CompleteLevel = player.CompleteLevel;
        Inventar = player.Inventar;
    }
}
