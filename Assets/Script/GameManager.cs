using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int score = 0;
    public bool PlayerDiedGameRestarted = false;
    public PlayerMovement movement;

    public Vector2 spawnPosition;
    public Transform playerTransform;
    public Transform hitBox;

    private void Start()
    {

    }
    private void Awake()
    {
        MakeSingleton();
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
        if (playerTransform.position.y < -1)
        {
            playerTransform.position = spawnPosition;
        }
    }

}
