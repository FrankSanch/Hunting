using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setTimer : MonoBehaviour
{
    private TMPro.TMP_Text textCurrentTime;


    void Start()
    {

        textCurrentTime = GetComponent<TMPro.TMP_Text>();
        textCurrentTime.SetText(GameData.currentTime.ToString());

        if (!GameData.enemyOn)
        {
            textCurrentTime.gameObject.SetActive(false);
        }
    }



    void Update()
    {
        GameData.currentTime -= Time.deltaTime;
        if (textCurrentTime.gameObject.activeSelf && GameData.currentTime >= 0)
        {
            textCurrentTime.SetText(GameData.currentTime.ToString());
        }

        if (GameData.currentTime <= 0)
        {
            textCurrentTime.SetText("0!");
        }

        if (GameData.currentTime <= -2)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }


    }
}
