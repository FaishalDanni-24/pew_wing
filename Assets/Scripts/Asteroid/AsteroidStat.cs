using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidStat : MonoBehaviour
{
    // Atribut asteroid
    private SpriteRenderer spriteR;
    public Sprite[] sprites;
    public bool comet;
    public bool smallAst;
    public int score = 10;

    // Dijalankan sekali saat load script
    void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        if (!comet)
        {
            // Pilih secara random sprite
            int spriteIndex = Random.Range(1, 5);

            switch (Random.Range(1, 5))
            {
                case 1:
                    spriteR.sprite = sprites[0];
                    break;
                case 2:
                    spriteR.sprite = sprites[1];
                    break;
                case 3:
                    spriteR.sprite = sprites[2];
                    break;
                case 4:
                    spriteR.sprite = sprites[3];
                    break;
                default:
                    break;
            }
        }
    }
}
