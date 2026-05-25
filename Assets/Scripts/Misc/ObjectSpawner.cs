using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Atribut
    private CameraController cam;
    public GameObject asteroidPrefab;
    public GameObject cometPrefab;
    public GameObject satellitePrefab;
    public GameObject redAlertPrefab;
    public GameObject blueAlertPrefab;

    // Atribut untuk spawning
    int[] asteroidNumArr = {
        6, 12, 24, 42, 66, 108, 174, 282, 456, 738
    };
    Vector3[] spawnCoords = new Vector3[4];
    float[] spawnRots = new float[4];

    // Atribut untuk cek
    public int totalDestroyedAsteroidCount;
    public int destroyedAsteroidCount;
    public bool allAsteroidDestroyed;
    public int currRound = 0;
    public int currSpawnedObject = 0;
    public float currTime;
    public float spawnRate;


    // Menambahkan jumlah asteroid yang hancur
    public void AddCount()
    {
        totalDestroyedAsteroidCount += 1;
        destroyedAsteroidCount += 1;
    }

    public void AddNumSpawned(int num)
    {
        if (currSpawnedObject + num < 0)
        {
            return;
        }
        currSpawnedObject += num;
    }

    // Method Spawner
    void GameObjectSpawner(GameObject gameObject, Vector3 position, float angleZ, int index)
    {
        Vector3 spawnPos = position;
        float spawnZ = angleZ;
        float spawnBufferDistanceX = 2.0f;
        float spawnBufferDistanceY = 2.0f;

        switch (index)
        {   
            // Kiri
            case 0:
                spawnPos = new Vector3(position.x - spawnBufferDistanceX, position.y + Random.Range(-1.0f, 1.0f), 0);
                spawnZ += Random.Range(-10.0f, 10.0f);
                break;
            // Kanan
            case 1:
                spawnPos = new Vector3(position.x + spawnBufferDistanceX, position.y + Random.Range(-1.0f, 1.0f), 0);
                spawnZ += Random.Range(-10.0f, 10.0f);
                break;
            // Bawah
            case 2:
                spawnPos = new Vector3(position.x + Random.Range(-5.0f, 5.0f), position.y - spawnBufferDistanceY, 0);
                spawnZ += Random.Range(-30.0f, 30.0f);
                break;
            // Atas
            case 3:
                spawnPos = new Vector3(position.x + Random.Range(-5.0f, 5.0f), position.y + spawnBufferDistanceY, 0);
                spawnZ += Random.Range(-30.0f, 30.0f);
                break;
            default:
                break;
        }

        // Spawn alert jika
        if (gameObject.CompareTag("Friend"))
        {
            GameObject alert = Instantiate(blueAlertPrefab, position, Quaternion.Euler(0, 0, angleZ + 180.0f));
            Destroy(alert, 2.0f);
        }
        else if (gameObject.CompareTag("Hostile"))
        {
            if (gameObject.GetComponent<AsteroidStat>().comet)
            {
                GameObject alert = Instantiate(redAlertPrefab, position, Quaternion.Euler(0, 0, angleZ + 180.0f));
                Destroy(alert, 2.0f);
            }
        }

        Instantiate(gameObject, spawnPos, Quaternion.Euler(0, 0, spawnZ));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        spawnCoords[0] = new Vector3(cam.borderLeft, 0, 0);
        spawnCoords[1] = new Vector3(cam.borderRight, 0, 0);
        spawnCoords[2] = new Vector3(0, cam.borderBottom, 0);
        spawnCoords[3] = new Vector3(0, cam.borderTop, 0);
        spawnRots[0] = -90;
        spawnRots[1] = 90;
        spawnRots[2] = 0;
        spawnRots[3] = 180;
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        Debug.Log("Current Round: " + currRound);
        // Logika round game
        if (destroyedAsteroidCount == asteroidNumArr[currRound])
        {
            if (currRound == asteroidNumArr.Length-1)
            {
                // Add change sceme to game over here
                currRound = 0;
            }
            currRound += 1;
            
        }

        // Atur spawnrate
        switch (currRound)
        {
            case 6:
                spawnRate = 3;
                break;
            default:
                break;
        }

        // Logika timing spawner
        currTime += Time.fixedDeltaTime;

        if (currTime > spawnRate)
        {
            // Logika pilih objek yang dispawn
            int randSpawnIndex1 = Random.Range(1, 3);
            int randSpawnIndex2 = Random.Range(0, 4);

            GameObject spawnPrefab = asteroidPrefab;
            
            // Pastikan spawner hanya spawn sesuai jumlah index dalam game
            if (currSpawnedObject == asteroidNumArr[currRound]/3)
            {
                return;
            }

            // Spawn objek spesial sesuai kriteria
            if (totalDestroyedAsteroidCount > 0 && totalDestroyedAsteroidCount % 10 == 0)
            {
                switch (randSpawnIndex1)
                {
                    case 1:
                        spawnPrefab = satellitePrefab;
                        break;
                    case 2:
                        spawnPrefab = cometPrefab;
                        break;
                    default:
                        break;
                }
            }
            

            GameObjectSpawner(spawnPrefab, spawnCoords[randSpawnIndex2], spawnRots[randSpawnIndex2], randSpawnIndex2);

            if (spawnPrefab.CompareTag("Hostile"))
            {
                if (!spawnPrefab.GetComponent<AsteroidStat>().comet)
                {
                    AddNumSpawned(1);
                }
            }
            
            currTime = 0;
        }
    }
}
