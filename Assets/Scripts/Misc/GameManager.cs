using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static string currGameScene;
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
            currGameScene = "GameOverScene";
            ChangeScene(currGameScene);
        }
    }
    public static void InputChangeScene(string sceneName)
    {
        if (Input.GetButtonDown("Jump"))
        {
            currGameScene = sceneName;
            ChangeScene(currGameScene);
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

        currGameScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {   
        switch (currGameScene)
        {
            case "StartScene":
                InputChangeScene("GameScene");
                break;
            case "GameScene":
                playerHealth = GameObject.Find("Player").GetComponent<PlayerStat>().GetHealth();
                playerScore = GameObject.Find("Player").GetComponent<PlayerStat>().GetScore();
                IsGameOver();
                break;
            case "GameOverScene":
                InputChangeScene("StartScene");
                break;
            default:
                break;
        }
    }
}
