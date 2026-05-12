using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    // Attributes
    public int health;
    public Boolean powerLevel;
    public float timeupPower = 10;
    private float timePowerPassed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Health: " + health);
    }

    void FixedUpdate()
    {
        timePowerPassed += Time.fixedDeltaTime;
    }
}
