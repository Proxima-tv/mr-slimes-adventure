using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour {
    public BossBehaviour boss;
    public GameObject ground;
    public GameObject jumpplates;

    bool isInState = false;
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Player") {
            if (boss.fight_state != 0)
            {
                boss.life--;

                if (boss.life < 5)
                {
                    boss.speed = 30;
                }

                boss.fight_state = 0;
                boss.bounces = 4;
                boss.lifeui.text = "Bosshealth: " + boss.life.ToString();
                isInState = true;
            }
            else if (boss.fight_state == 0 && isInState)
            {
                /**
                 * ==================================================== *
                 * Caught State                                         *
                 * triggered once the boss is attacked in angerstate    *
                 * the state simulates uncautiones                      *
                 * ==================================================== *
                 * Reduce life
                 * update display
                 * reset state
                 * reset bounces
                 * reset bounces to 4
                 * disable instate
                 */
                boss.life--;
                
                // Destroy when life is 0
                if (boss.life <= 0)
                {
                    Debug.Log("dead");
                    // If Boss dies start final state
                    // The ground gets removed and the players needs to escape out of the arena
                    Destroy(ground.gameObject);
                    Destroy(transform.parent.gameObject);
                }
                
                boss.lifeui.text = "Bosshealth: " + boss.life.ToString();
                boss.fight_state = 1;
                boss.bounces = 0;
                boss.wave = 4;
                isInState = false;
            }
        }
    }
}
