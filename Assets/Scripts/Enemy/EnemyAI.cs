using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float minRange = 10f;
    public Transform player;
    public bool playerInRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "worldborder")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Killzone")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("I moved out of grounds");
            speed = ((float)speed * -1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerInRange = Vector3.Distance(transform.position, player.position) < minRange;
        if (playerInRange)
        {
            Vector3 move = new Vector3(-1 * speed, rb.velocity.y, 0f);
            rb.velocity = move;
        }
    }
}
