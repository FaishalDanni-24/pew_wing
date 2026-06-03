using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    // Attributes
    private Transform fireBarrel1;
    private Transform fireBarrel2;
    private Transform fireBarrel3;
    private PlayerStat stat;
    public GameObject laserPrefab;
    public float laserSpeed;

    [Header("Pengaturan Audio Tembakan")]
    public AudioSource audioSource;
    public AudioClip shootSFX;

    // Fungsi untuk menembak
    void Shoot(bool powerup)
    {
        GameObject laser1, laser2;
        Rigidbody2D rbLaser1, rbLaser2;
        
        if (powerup)
        {
            laser1 = Instantiate(laserPrefab, fireBarrel2.position, fireBarrel2.rotation);
            rbLaser1 = laser1.GetComponent<Rigidbody2D>();
            rbLaser1.velocity = new Vector2(laser1.transform.up.x * laserSpeed, laser1.transform.up.y * laserSpeed);

            laser2 = Instantiate(laserPrefab, fireBarrel3.position, fireBarrel3.rotation);
            rbLaser2 = laser2.GetComponent<Rigidbody2D>();
            rbLaser2.velocity = new Vector2(laser2.transform.up.x * laserSpeed, laser2.transform.up.y * laserSpeed);
        }
        else
        {
            laser1 = Instantiate(laserPrefab, fireBarrel1.position, fireBarrel1.rotation);
            rbLaser1 = laser1.GetComponent<Rigidbody2D>();
            rbLaser1.velocity = new Vector2(laser1.transform.up.x * laserSpeed, laser1.transform.up.y * laserSpeed);
        }

        // Trigger suara tembakan setelah peluru di-instantiate
        if (audioSource != null && shootSFX != null)
        {
            audioSource.PlayOneShot(shootSFX);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        stat = GetComponent<PlayerStat>();
        fireBarrel1 = GameObject.Find("FireBarrel_Normal").GetComponent<Transform>();
        fireBarrel2 = GameObject.Find("FireBarrel1_Powered").GetComponent<Transform>();
        fireBarrel3 = GameObject.Find("FireBarrel2_Powered").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){Shoot(stat.GetPowerLevel());}
    }
}