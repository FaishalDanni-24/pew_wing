using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(10);
            Destroy(gameObject);
            // Buat logika buat pecah jadi asteroid kecil
        }

        if (collision.gameObject.CompareTag("Friend"))
        {
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
