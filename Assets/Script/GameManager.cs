using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int score = 0;
    public bool PlayerDiedGameRestarted = false;

    public float restartDelay = 2f;
    public Vector2 spawnPosition;
    bool gameEnded = false;
    private Transform player;

    private void Start()
    {
       
    }
    private void Awake()
    {
        MakeSingleton();
        player = GameObject.Find("Player").transform;
        
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameEnded = false;
        player = GameObject.Find("Player").transform;
    }

    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        if(player.position.y < -1)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("game over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
