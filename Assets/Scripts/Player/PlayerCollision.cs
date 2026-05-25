using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // When trigger collided
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<ItemLogic>().type == "Health")
        {
            gameObject.GetComponent<PlayerStat>().AddHealth(1);
        }
        if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<ItemLogic>().type == "Laser")
        {
            gameObject.GetComponent<PlayerStat>().SetPowerLevel();
        }
    }

    // When object collided
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Hostile")
        {
            gameObject.GetComponent<PlayerStat>().AddHealth(-1);
        }    
    }
}
