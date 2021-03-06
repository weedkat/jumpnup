using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Paused(InputAction.CallbackContext context)
    {
        if (GamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
