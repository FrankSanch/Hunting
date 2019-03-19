using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static bool windOn = false;
    public static bool targetMobileOn = false;


    private void Awake()
    {
        //L'objet ne sera pas détruit quand on change de scène
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
