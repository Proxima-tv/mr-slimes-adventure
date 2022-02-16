using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public int speed = 0;
    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "runner-stop")
        {
            Destroy(this.gameObject);
        }
    }
}
