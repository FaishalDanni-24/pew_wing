using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    // Attributes
    public int health;
    public Boolean powerLevel;
    public float timeupPower = 10;
    private float timePowerPassed;
    private float score;

    public void addScore(int score)
    {
        this.score += score;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Health: " + health);
        Debug.Log("Player Score: " + score);

    }

    void FixedUpdate()
    {
        timePowerPassed += Time.fixedDeltaTime;
    }
}
