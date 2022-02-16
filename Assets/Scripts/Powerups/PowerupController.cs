using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerupController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // Detects collisions with the player and destroys the object on collision enter
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("i have been used");
            Destroy(this.gameObject);
        }
    }
}
