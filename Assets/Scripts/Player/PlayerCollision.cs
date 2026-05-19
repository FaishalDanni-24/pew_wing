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
            Debug.Log("You got health powerup!");
            gameObject.GetComponent<PlayerStat>().addHealth(1);
        }
        if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<ItemLogic>().type == "Laser")
        {
            Debug.Log("You got laser powerup!");
            gameObject.GetComponent<PlayerStat>().setPowerLevel();
        }
    }

    // When object collided
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Hostile")
        {
            gameObject.GetComponent<PlayerStat>().addHealth(-1);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
