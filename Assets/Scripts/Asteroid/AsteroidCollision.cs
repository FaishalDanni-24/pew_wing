using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    AsteroidStat stat;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Player").GetComponent<PlayerStat>().addScore(stat.score);
            // Buat logika buat pecah jadi asteroid kecil
            // Instantiate();
            Destroy(gameObject);
            
        }

        if (collision.gameObject.CompareTag("Friend"))
        {
            Destroy(gameObject);
        }        
    }

    // Start is called before the first frame update
    void Start()
    {
        stat = GetComponent<AsteroidStat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
