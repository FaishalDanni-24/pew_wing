using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(-100);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Hostile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(-50);
            Destroy(gameObject);
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
