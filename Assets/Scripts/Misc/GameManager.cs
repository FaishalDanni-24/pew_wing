using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static int currGameState = 1;
    static int playerScore;
    static int playerHealth;

    
    // Method yang dipakai GameManager
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void IsGameOver()
    {
        if (playerHealth <= 0 || GameObject.Find("Spawner").GetComponent<ObjectSpawner>().GetRound(true) == GameObject.Find("Spawner").GetComponent<ObjectSpawner>().GetRound(false)-1)
        {
            currGameState = 2;
            ChangeScene("GameOverScene");
        }
    }

    // Dijalankan sekali saat load script
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        switch (currGameState)
        {
            case 0:
                // Run script start menu
                break;
            case 1:
                playerHealth = GameObject.Find("Player").GetComponent<PlayerStat>().GetHealth();
                playerScore = GameObject.Find("Player").GetComponent<PlayerStat>().GetScore();
                IsGameOver();
                break;
            case 2:
                // Run script gameover menu
                break;
            default:
                break;
        }
    }
}
