using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpboostpowerup : MonoBehaviour
{
    public float boost = 10f;
    public PlayerMovement player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.JumpBoost = true;
            Destroy(this);
        }
    }

}
