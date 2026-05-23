using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Atribut
    private CameraController cam;
    public GameObject asteroidPrefab;
    public GameObject smallAsteroidPrefab;
    public GameObject cometPrefab;
    public GameObject satellitePrefab;

    // Atribut untuk spawning
    int[] asteroidNumArr = {2, 3, 5, 8, 12};
    Vector3[] spawnCoords = new Vector3[4];
    float[] spawnRots = new float[4];
    int[] cometIndex = {10};

    // Atribut untuk cek
    private int totalDestroyedAsteroidCount;
    public int destroyedAsteroidCount;
    public bool allAsteroidDestroyed;
    private int currRound = 0;
    public float currTime;
    public float spawnRate;


    // Menambahkan jumlah asteroid yang hancur
    public void AddCount()
    {
        totalDestroyedAsteroidCount += 1;
        destroyedAsteroidCount += 1;
    }

    // Method Spawner
    void GameObjectSpawner(GameObject gameObject, Vector3 position, float angleZ)
    {
        Instantiate(gameObject, position, Quaternion.Euler(0, 0, angleZ));
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
        // Logika timing spawner
        currTime += Time.fixedDeltaTime;

        if (currTime > spawnRate)
        {
            // Logika pilih objek yang dispawn
            GameObjectSpawner(asteroidPrefab, spawnCoords[0], spawnRots[0]);
            currTime = 0;
        }
    }
}
