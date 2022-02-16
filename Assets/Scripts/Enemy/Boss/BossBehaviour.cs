using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
/**
 * ai chasing as follows: 
 * https://answers.unity.com/questions/734630/make-enemy-chase-player-in-topdown-2d.html
 */

public class BossBehaviour : MonoBehaviour {

    public bool chasing = true;
    public bool fight = false;
    public int life = 4;
    public Text lifeui;
    Rigidbody2D rb;

    [Header("Spawnable")]
    public GameObject minion_left;
    public GameObject minion_right;
    public GameObject mctrl;

    [Header("Map Values")]
    public GameObject wl;
    public GameObject wr;
    public GameObject JumpPlates;

    [Header("AI Values")]
    public Transform target;
    public int fight_state = 2;
    public int bounces = 4;
    public int wave = 4;
    int lastState;

    [Header("Movement Values")]
    public int x = 1;
    public int speed = 6;
    public float center_pos = 173.3F;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stateswitch")
        {
            chasing = false;
            fight = true;

            Destroy(mctrl);
            // mctrl.SetActive(false);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            life--;
            lifeui.text = "boss health: " + life.ToString();
            fight_state = 0;
            if (life <= 0)
            {
                if (life <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (collision.gameObject.tag == "runner-stop")
        {
            // fight_state = 2;
            // bounces = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        if (chasing) {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        } else if (fight) {
            switch (fight_state) {
                case 0:
                    lastState = 0;

                    if(transform.position.x >= 224.65f)
                    {
                        Debug.Log("Direction Change");
                        x = x * (-1);
                        bounces--;
                        Debug.Log(x);
                        Debug.Log(bounces);
                    } else if(transform.position.x <= 125.33f)
                    {
                        Debug.Log("Direction Change");
                        x = x * (-1);
                        bounces--;
                        Debug.Log(x);
                        Debug.Log(bounces);
                    }

                    if (bounces > 0)
                    {
                        wl.SetActive(false);
                        wr.SetActive(false);
                        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
                        rb.velocity = move;
                    }
                    else if (bounces <= 0)
                    {
                        if (this.transform.position.x < center_pos)
                        {
                            Vector3 move = new Vector3(1 * speed, rb.velocity.y, 0f);
                            rb.velocity = move;
                            wl.SetActive(true);
                            wr.SetActive(true);
                        }
                        else
                        {
                            fight_state = 1;
                            bounces = 4;
                        }
                    }
                    break;
                case 1:
                    StartCoroutine(caught());
                    break;
            }
        }
    }

    public IEnumerator caught() {
        // Reenable properties
        if (!wl.activeSelf) { wl.SetActive(true); }
        if (!wr.activeSelf) { wr.SetActive(true); }

        while (wave > 0) {
            // Calculate spawn positions
            float left = transform.position.x + 5f;
            float right = transform.position.x - 5f;
            float y = transform.position.y;
            float z = transform.position.z;

            // Debug.Log("Spawning");
            Instantiate(minion_left, new Vector3(right, y, z), transform.rotation);
            Instantiate(minion_right, new Vector3(left, y, z), transform.rotation);
            //fight_state = 0;

            wave--;
            yield return new WaitForSeconds(0.5f);
        }
        if (!JumpPlates.activeSelf) { JumpPlates.SetActive(true); }
    }
}