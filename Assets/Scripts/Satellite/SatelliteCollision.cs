using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteCollision : MonoBehaviour
{
    // Atribut
    SatelliteStat stat;

    // --- TAMBAHAN AUDIO ---
    public AudioClip satelliteHitSound;
    // ----------------------

    // Ketika tabrakan antar dua collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Putar SFX Satelit terkena tembakan
            if (satelliteHitSound != null) 
            {
                AudioSource.PlayClipAtPoint(satelliteHitSound, Camera.main.transform.position, 1f);
            }
            GameObject.Find("Player").GetComponent<PlayerStat>().AddScore(-stat.score);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Hostile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().AddScore(-(stat.score/2));
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        stat = GetComponent<SatelliteStat>();
    }
}