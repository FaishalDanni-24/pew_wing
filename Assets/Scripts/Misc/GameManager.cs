using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static string currGameScene;
    public static int playerScore;
    public static int playerHealth;
    public Animator transition;
    public float transitionTime = 1f;
    static bool isChangingScene = false;


    // --- TAMBAHAN AUDIO & TRANSISI ---
    public AudioClip uiClickSound;
    private AudioSource audioSource; // AudioSource internal yang menempel di GameManager
    private static bool isTransitioning = false; // Mencegah spasi ditekan berkali-kali
    // ---------------------------------

    // Method yang dipakai GameManager
    public static void ChangeScene(string sceneName)
    {
        Instance.StartCoroutine(Instance.LoadLevel(sceneName));
    }
    

    IEnumerator LoadLevel(string sceneName)
    {
    transition.SetTrigger("Start"); // terang ke gelap
    yield return new WaitForSeconds(transitionTime);

    currGameScene = sceneName;
    SceneManager.sceneLoaded += OnSceneLoaded;
    SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        transition.SetTrigger("End");
        isChangingScene = false;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public static void IsGameOver()
    {
       if (isChangingScene) return;

        bool isDead = playerHealth <= 0;
    
        bool isLastRound = false;
        GameObject spawner = GameObject.Find("Spawner");
        if (spawner != null)
        {
            ObjectSpawner objectSpawner = spawner.GetComponent<ObjectSpawner>();
            isLastRound = objectSpawner.GetRound(true) == objectSpawner.GetRound(false) - 1;
        }

        if (isDead || isLastRound)
        {
            isChangingScene = true;
            ChangeScene("GameOverScene");
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
        isChangingScene = false;
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
            GameObject player = GameObject.Find("Player");
                if (player == null) return;
                playerHealth = player.GetComponent<PlayerStat>().GetHealth();
                playerScore = player.GetComponent<PlayerStat>().GetScore();
                Debug.Log("Health: " + playerHealth + " | isChangingScene: " + isChangingScene);
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