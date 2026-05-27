using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    // Attributes
    private bool invincibility = false;
    private float timeInvinciblePassed;
    private float timeupInvincible = 5;
    public int health = 5;
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
        if (invincibility)
        {
            return;
        }
        this.health += health;
    }

    public void SetPowerLevel(bool powerLevel)
    {
        this.powerLevel = powerLevel;
    }
    public bool GetPowerLevel()
    {
        return powerLevel;
    }

    public void SetInvicinbility(bool invincibility)
    {
        this.invincibility = invincibility;
    }
    public bool GetInvicinbility()
    {
        return invincibility;
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
            if (timePowerPassed > timeupPower)
            {
                SetPowerLevel(false);
                timePowerPassed = 0;
            }
        }

        if (GetInvicinbility())
        {
            timeInvinciblePassed += Time.fixedDeltaTime;
            if (timeInvinciblePassed > timeupInvincible)
            {
                SetInvicinbility(false);
                timeInvinciblePassed = 0;
            }
        }
    }
}
