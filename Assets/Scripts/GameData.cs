using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class GameData : MonoBehaviour
{
    public static bool windOn = true;
    public static bool targetMobileOn = false;
    

    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = 100;
    private Random random = new Random();

    private void Awake()
    {
        //L'objet ne sera pas détruit quand on change de scène
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
        //Le vent en x en y et en z est un nombre aléatoire entre 1 et 4
        if (windOn) 
             windVelocity = new Vector3(10, 0, 10);
            //windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity), random.Next(minWindVelocity, maxWindVelocity), random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
    }

    void Update()
    {

    }
}
