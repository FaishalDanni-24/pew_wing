using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static string currGameScene;
    static int playerScore;
    static int playerHealth;

    // --- TAMBAHAN AUDIO & TRANSISI ---
    public AudioClip uiClickSound;
    private AudioSource audioSource; // AudioSource internal yang menempel di GameManager
    private static bool isTransitioning = false; // Mencegah spasi ditekan berkali-kali
    // ---------------------------------

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
        // Memastikan input "Jump" (Spasi) ditekan dan belum dalam mode transisi pindah scene
        if (Input.GetButtonDown("Jump") && !isTransitioning)
        {
            isTransitioning = true; // Kunci transisi agar tidak dieksekusi dobel

            // Menggunakan PlayOneShot lewat AudioSource GameManager agar suara TIDAK hancur saat scene berganti
            if (Instance != null && Instance.uiClickSound != null && Instance.audioSource != null)
            {
                Instance.audioSource.PlayOneShot(Instance.uiClickSound);
            }

            // Jalankan delay Coroutine untuk memberikan jeda visual yang smooth sebelum pindah scene
            if (Instance != null)
            {
                Instance.StartCoroutine(Instance.LoadSceneWithDelay(sceneName, 0.4f)); // Jeda 0.4 detik
            }
        }
    }

    // Coroutine untuk mengatur delay transisi scene
    private IEnumerator LoadSceneWithDelay(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        currGameScene = sceneName;
        ChangeScene(currGameScene);
        
        isTransitioning = false; // Buka kembali kunci transisi di scene baru
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
        
        // Mengonfigurasi AudioSource internal pada objek GameManager secara otomatis
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.spatialBlend = 0f; // Set ke 2D standar agar volume terdengar merata penuh

        isTransitioning = false; 
        currGameScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {   
        switch (currGameScene)
        {
            case "StartScene":
                // Saat berada di StartScene, menekan spasi akan memicu perpindahan ke GameScene
                InputChangeScene("GameScene");
                break;
            case "GameScene":
                playerHealth = GameObject.Find("Player").GetComponent<PlayerStat>().GetHealth();
                playerScore = GameObject.Find("Player").GetComponent<PlayerStat>().GetScore();
                IsGameOver();
                break;
            case "GameOverScene":
                // Saat berada di GameOverScene, menekan spasi akan memicu perpindahan kembali ke StartScene
                InputChangeScene("StartScene");
                break;
                
            default:
                break;
        }
    }
}