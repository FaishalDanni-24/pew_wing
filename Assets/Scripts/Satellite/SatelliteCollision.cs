using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollision : MonoBehaviour
{
    // Atribut
    SatelliteStat stat;


    // Ketika tabrakan antar dua collider
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Dijalankan sekali saat load script
    void Awake()
    {
        stat = GetComponent<SatelliteStat>();
    }
}
