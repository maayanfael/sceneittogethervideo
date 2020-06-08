using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static bool isAppPaused = false;
    public GameObject settingsMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isAppPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            
        }
    }

    public void Pause()
    {
        settingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isAppPaused = true;
    }

    public void Resume()
    {
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isAppPaused = false;
    }

    public void ExitApp() {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
