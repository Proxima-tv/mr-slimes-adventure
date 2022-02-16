using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public stateSaving save;
    public GameObject Bullet;
    public LevelCheck goal;
    public float speed = 11f;

    [Header("Physics")]
    Rigidbody2D rb;
    BoxCollider2D box;

    [Header("Game Objects")]
    public Transform cam;

    //M�nzenanzeige 
    [Header ("Stats")]
    public int Coins = 0;
    public int Ammo = 0;
    public int[] CompleteLevel;
    public Object[] Inventar;

    //lebensanzeige
    [Header("Player Health & Respawn")]
    public int life = 3;
    public float x = -34.2f;
    public float y = -2.4f;
        
    [Header("UI")]
    public Text lifetxt;
    public Text coins;

    public bool gameover;
    public GameObject GameOverPanel;
    public Text AmmoUI;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        //Leben anzeigen lassen
        lifetxt.text = "Life: " + life.ToString();       
    }

    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.collider.tag);

        if(col.collider.tag == "enemyBody") {
            // Debug.Log("Enemy Attack");
            rb.AddForce(new Vector2(-20, 0), ForceMode2D.Impulse);
            life--;
            save.setLive(life);
            lifetxt.text = "Life: " + life.ToString();

            // Debug.Log(life);

            if (life <= 0) {
                // Debug.Log("Spieler ist tot");
                gameover = true;
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (col.collider.tag == "jumpplate") {
            rb.AddForce(new Vector2(0, 50), ForceMode2D.Impulse);
        }

        if (col.collider.tag == "bossplate") {
            rb.AddForce(new Vector2(0, 70), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "coin") {
            Coins++;
            coins.text = "Coins: " + Coins.ToString() + " / " + goal.needed;
        }

        if (col.tag == "1UP")
        {
            life++;
            lifetxt.text = "Life: " + life.ToString();
        }
        
        if (col.tag == "Killzone") {
            Debug.Log("Spieler ist tot");

            life--;
            lifetxt.text = "Life: " + life.ToString();
            if (life > 0) {
                transform.SetPositionAndRotation(new Vector3(x, y, transform.position.z), transform.rotation);
                cam.SetPositionAndRotation(new Vector3(x, cam.position.y, cam.position.z), cam.rotation);
            } else {
                gameover = true;
                GameOverPanel.SetActive(true);
            }
        }
    }
}
