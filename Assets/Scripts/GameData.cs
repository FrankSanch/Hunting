﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static bool windOn = true;
    public static bool targetMobileOn = false;
    



    private void Awake()
    {
        //L'objet ne sera pas détruit quand on change de scène
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
        //Le vent en x en y et en z est un nombre aléatoire entre 1 et 4
            
    }

    void Update()
    {

    }
}
