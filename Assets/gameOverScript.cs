using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverScript : MonoBehaviour
{

    public TMPro.TMP_Text windspeedText;
    float timer=0;
    float timestart = 0;
    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
        int highScore = 0;
        windspeedText.SetText("Game Over \n Your score in " + GameData.level + " is " + GameData.totalScore + "\nYour High score is " + highScore);
        if (GameData.level == "Level: Statique")
        {
            highScore = GameData.bestScoreStat;
            if (GameData.totalScore > GameData.bestScoreStat)
            {
                GameData.bestScoreStat = GameData.totalScore;
                windspeedText.SetText("Game Over \n Your score in " + GameData.level + " is " + GameData.totalScore + "\nNew High Score");
            }
        }
        else if (GameData.level == "Level: Mobile")
        {
            highScore = GameData.bestScoreMob;
            if (GameData.totalScore > GameData.bestScoreMob)
            {
                GameData.bestScoreMob = GameData.totalScore;
                windspeedText.SetText("Game Over \n Your score in " + GameData.level + " is " + GameData.totalScore + "\nNew High Score");
            }

        }
        else if (GameData.level == "Level: Marathon")
        {
            highScore = GameData.bestScoreMar;
            if (GameData.totalScore > GameData.bestScoreMar)
            {
                GameData.bestScoreMar = GameData.totalScore;
                windspeedText.SetText("Game Over \n Your score in " + GameData.level + " is " + GameData.totalScore + "\nNew High Score");
            }
        }
        else if (GameData.level == "Level: Hunt")
        {
            highScore = GameData.bestScoreHunt;
            if (GameData.totalScore > GameData.bestScoreHunt)
            {
                GameData.bestScoreHunt = GameData.totalScore;
                windspeedText.SetText("Game Over \n Your score in " + GameData.level + " is " + GameData.totalScore + "\nNew High Score");

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        float timer = Time.time;
        if(timer-timestart>5)
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
