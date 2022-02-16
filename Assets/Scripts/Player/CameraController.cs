using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform player;
    public bool movable = false;
    public GameObject pauseObject;
    public float lowestPoint;

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > transform.position.x && !movable) {
            transform.SetPositionAndRotation(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
        else if(movable)
        {
            if(player.transform.position.y > lowestPoint) {
                transform.SetPositionAndRotation(new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), transform.rotation);
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(player.transform.position.x, lowestPoint, transform.position.z), transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseObject.activeSelf)
            {
                pauseObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
