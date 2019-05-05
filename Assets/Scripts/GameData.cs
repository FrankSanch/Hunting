using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static bool windOn = true;
    public static bool targetMobileOn = false;
    public static bool enemyOn = false;
    public static bool timerMarathon = false;
    public static int ammoArrow = 0;
    public static string level = "Level";
    public static float currentTime;

    public static bool marathon = false;
    public static bool hunt = false;
    public static bool statique = false;
    public static bool mobile = false;

    public static int test = 0;


    private void Awake()
    {
        //L'objet ne sera pas détruit quand on change de scène
        DontDestroyOnLoad(this.gameObject);
    }

   
}
