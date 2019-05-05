using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas; 
   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            /*
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }*/
        }
        
    }
    /*
    void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("ReturnToMainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }*/
}
