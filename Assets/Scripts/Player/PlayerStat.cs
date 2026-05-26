using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    // Attributes
    private int health = 5;
    private int score;
    private Boolean powerLevel = false;
    private float timePowerPassed;
    private float timeupPower = 10;
    

    // Behavior tambahan yang terjadi di player
    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int health)
    {
        this.health += health;
    }

    public void SetPowerLevel()
    {
        powerLevel = !powerLevel;
    }

    public bool GetPowerLevel()
    {
        return powerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary, will be displayed using GUI
        Debug.Log("Player Health: " + health);
        Debug.Log("Player Score: " + score);
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        if (GetPowerLevel())
        {
            timePowerPassed += Time.fixedDeltaTime;
        if (timePowerPassed > timeupPower && powerLevel)
        {
            SetPowerLevel();
            timePowerPassed = 0;
        }
        }
    }
}
