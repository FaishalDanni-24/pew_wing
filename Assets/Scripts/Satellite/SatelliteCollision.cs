using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollision : MonoBehaviour
{
    SatelliteStat stat;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(-stat.score);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Hostile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(-(stat.score/2));
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<SatelliteStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
