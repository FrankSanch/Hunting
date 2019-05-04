using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }


    public void StartNormalModeStatique()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.enemyOn = false;
        GameData.ammoArrow = 10;
        GameData.level = "Level: Statique";
        GameData.statique = true;
        GameData.test = 1;
        Cursor.visible = false;
        GameData.enemyOn = false;
    }

    public void StartNormalModeMobile()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = true;
        GameData.ammoArrow = 10;
        GameData.level = "Level: Mobile";
        GameData.mobile = true;
        GameData.test = 1;
        Cursor.visible = false;
        GameData.enemyOn = false;
    }

    public void StartMarathonMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = false;
        GameData.targetMobileOn = false;
        GameData.marathon = true;
        GameData.timerMarathon = true;
        GameData.ammoArrow = 3;
        GameData.level = "Level: Marathon";
        GameData.test = 1;
        Cursor.visible = false;
        GameData.enemyOn = false;
    }

    public void StartHuntMode()
    {
        GameData.hunt = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameData.windOn = true;
        GameData.targetMobileOn = true;
        GameData.enemyOn = true;
        GameData.ammoArrow = 4;
        GameData.level = "Level: Hunt";
        GameData.test = 1;
        Cursor.visible = false;

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
