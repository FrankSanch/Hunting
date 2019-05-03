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
        GameData.ammoArrow = 10;
        GameData.level = "Level: Statique";
        GameData.statique = true;
        GameData.arrowMissed = 0;
    }

    public void StartNormalModeMobile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = true;
        GameData.ammoArrow = 10;
        GameData.level = "Level: Mobile";
        GameData.arrowMissed = 0;
        GameData.mobile = true;
    }


    public void StartMarathonMode()
    {
        //Debug.Log("wtf");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.marathon = true;
        GameData.arrowMissed = 0;

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
        GameData.hunt = true;
        GameData.arrowMissed = 0;
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
