using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    // Atribut untuk tabrakan
    public GameObject smallAstPrefab;
    public GameObject powerPrefab;
    public GameObject healthPrefab;
    AsteroidStat stat;


    // Ketika collider masuk ke collider lain
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tabrakan laser dengan Asteroid besar
        if (collision.gameObject.CompareTag("Projectile") && !stat.smallAst)
        {
            Vector3[] spawnCoords= new Vector3[3];

            spawnCoords[0] = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0);
            spawnCoords[1] = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0);
            spawnCoords[2] = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f), 0);

            Instantiate(smallAstPrefab, spawnCoords[0], Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            Instantiate(smallAstPrefab, spawnCoords[1], Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            Instantiate(smallAstPrefab, spawnCoords[2], Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            
            GameObject.Find("Spawner").GetComponent<ObjectSpawner>().AddNumSpawned(-1);
            Destroy(gameObject);
        }

        // Tabrakan laser dengan asteroid kecil
        if (collision.gameObject.CompareTag("Projectile") && stat.smallAst && !stat.comet)
        {
            int spawnItem = Random.Range(1, 21);
            GameObject itemPrefab = null;

            switch (spawnItem)
            {  
                case 4:
                    itemPrefab = healthPrefab;
                    Instantiate(healthPrefab, transform.position, Quaternion.Euler(0, 0, 0));
                    break;
                case 17:
                    itemPrefab = powerPrefab;
                    Instantiate(powerPrefab, transform.position, Quaternion.Euler(0, 0, 0));
                    break;
                default:
                    break;
            }
            GameObject.Find("Spawner").GetComponent<ObjectSpawner>().AddCount();
            GameObject.Find("Player").GetComponent<PlayerStat>().AddScore(stat.score);
            Destroy(gameObject);
        }
        
        // Tabrakan laser dengan comet
        if (collision.gameObject.CompareTag("Projectile") && stat.comet)
        {
            GameObject.Find("Spawner").GetComponent<ObjectSpawner>().AddCount();
            GameObject.Find("Player").GetComponent<PlayerStat>().AddScore(stat.score*10);
            Destroy(gameObject);
        }

        // Tabrakan asteroid dengan satelit
        if (collision.gameObject.CompareTag("Friend"))
        {
            GameObject.Find("Spawner").GetComponent<ObjectSpawner>().AddNumSpawned(-1);
            Destroy(gameObject);
        }        
    }

    // Dijalankan sekali saat load script
    void Awake()
    {
        stat = GetComponent<AsteroidStat>();
    }
}
