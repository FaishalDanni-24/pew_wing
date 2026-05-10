using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    // Attributes
    private Transform fireBarrel;
    public GameObject laserPrefab;
    public float laserSpeed;

    void shoot()
    {
        GameObject laser = Instantiate(laserPrefab, fireBarrel.transform.position, fireBarrel.transform.rotation);
        Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();
        rbLaser.velocity = new Vector2(laser.transform.up.x * laserSpeed, laser.transform.up.y * laserSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        fireBarrel = GameObject.Find("FireBarrel").GetComponent<Transform>();
        laserPrefab = GameObject.Find("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){shoot();}
    }
}
