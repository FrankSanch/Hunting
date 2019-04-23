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
        GameData.ammoArrow = 1;
        GameData.level = "Level: Statique";
    }

    public void StartNormalModeMobile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = true;
        GameData.ammoArrow = 2;
        GameData.level = "Level: Mobile";
    }

    //What the frick is this
    public void StartMarathonMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.timerMarathon = true;
        GameData.ammoArrow = 3;
        GameData.level = "Level: Marathon";
    }

    public void StartHuntMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = true;
        GameData.targetMobileOn = true;
        GameData.enemyOn = true;
        GameData.ammoArrow = 4;
        GameData.level = "Level: Hunt";
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
