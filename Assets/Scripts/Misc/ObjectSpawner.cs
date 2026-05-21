using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Atribut
    CameraController cam;
    public GameObject asteroid;

    // Atribut untuk spawning
    int[] asteroidNumArr = {2, 3, 5, 8, 12};
    Vector3[] spawnCoords = {};
    int[] cometIndex = {10};

    // Atribut untuk cek
    public int destroyedAsteroidCount;
    public bool allAsteroidDestroyed;
    private int currRound = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
