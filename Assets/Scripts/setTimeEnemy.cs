using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTimeEnemy : MonoBehaviour {

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
        if (textCurrentTime.gameObject.activeSelf && GameData.currentTime >= 0)
        {
            textCurrentTime.SetText(GameData.currentTime.ToString());
        }
        
    }

}
