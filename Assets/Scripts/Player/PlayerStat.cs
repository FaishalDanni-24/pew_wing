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
    

    public void addScore(int score)
    {
        this.score += score;
    }

    public void addHealth(int health)
    {
        this.health += health;
    }

    public void setPowerLevel()
    {
        powerLevel = !powerLevel;
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
        if (timePowerPassed > timeupPower)
        {
            setPowerLevel();
            timePowerPassed = 0;
        }
    }
}
