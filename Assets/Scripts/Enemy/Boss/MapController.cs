using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "stateswitch")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "stateswitch") {
            this.enabled = false;
            Destroy(this.gameObject);
        } else {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
