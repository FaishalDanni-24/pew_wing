using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{

    public PlayerStat playerStat;
    public Image healthBarImage;
    public Sprite[] healthSprites; // 0 = full, 5 = empty

    private int previousHealth;

    // Start is called before the first frame update
    void Start()
    {
        previousHealth = playerStat.GetHealth();
        UpdateHealth(previousHealth);
    }

    // Update is called once per frame
    void Update()
    {
         int currentHealth = playerStat.GetHealth();

        if (currentHealth != previousHealth)
        {
            UpdateHealth(currentHealth);
            previousHealth = currentHealth;
        }
    }

    void UpdateHealth(int currentHealth)
{
    int index = Mathf.Clamp(5 - currentHealth, 0, healthSprites.Length - 1);
    healthBarImage.sprite = healthSprites[index];
}
}
