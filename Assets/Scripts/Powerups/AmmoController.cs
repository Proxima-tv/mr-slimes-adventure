using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public PlayerController player;
    public Text AmmoUI;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.Ammo++;
            AmmoUI.text = "Ammo: " + player.Ammo.ToString();
            Debug.Log("i have been used");
            Destroy(this.gameObject);
        }
    }
}
