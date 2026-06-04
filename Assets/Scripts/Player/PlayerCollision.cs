using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Pengaturan Audio Interaksi")]
    public AudioSource audioSource; // Bisa pakai Audio Source yang sama dengan tembakan
    public AudioClip healthUpSFX;
    public AudioClip powerUpSFX;
    public AudioClip hitSFX; // Suara saat pesawat tertabrak

    // When trigger collided
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<ItemLogic>().type == "Health")
        {
            gameObject.GetComponent<PlayerStat>().AddHealth(1);
            
            // Trigger suara dapat Health
            if (audioSource != null && healthUpSFX != null) audioSource.PlayOneShot(healthUpSFX);
        }
        if (collision.gameObject.CompareTag("Powerup") && collision.gameObject.GetComponent<ItemLogic>().type == "Laser")
        {
            gameObject.GetComponent<PlayerStat>().SetPowerLevel(true);
            
            // Trigger suara dapat Powerup Laser
            if (audioSource != null && powerUpSFX != null) audioSource.PlayOneShot(powerUpSFX);
        }
    }

    // When object collided
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Hostile")
        {
            gameObject.GetComponent<PlayerStat>().AddHealth(-1);
            gameObject.GetComponent<PlayerStat>().SetInvicinbility(true);
            
            // Trigger suara saat tertabrak/terkena damage
            if (audioSource != null && hitSFX != null) audioSource.PlayOneShot(hitSFX);
        }    
    }
}