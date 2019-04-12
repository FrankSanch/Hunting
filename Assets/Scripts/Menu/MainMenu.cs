using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNormalModeStatique()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.enemyOn = true;
    }

    public void StartNormalModeMobile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = true;
    }

    //What the frick is this
    public void StartMarathonMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.timerMarathon = true;
    }

    public void StartHuntMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = true;
        GameData.targetMobileOn = true;
        GameData.enemyOn = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
