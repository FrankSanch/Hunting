﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class enemySpawner : MonoBehaviour
{

    private List<GameObject> enemies = new List<GameObject>();
   

    private bool enableEnemies = GameData.enemyOn;

    private Random random;

    public GameObject enemyPrefab;

    public float enemyScale = 3f;

    public int enemyWave = 0;
    public int numberOfWaves = 12;
    private int enemiesPerWave = 2;



    //distance maximal et minimal pour faire apparaître les enemies
    private int maxDistance = 40;
    private int minDistance = 15;

    void Start()
    {
        if (enableEnemies)
        {
            GameData.currentTime = 10;
            enableEnemies = GameData.enemyOn;
            random = new Random();
            SpawnEnemies(enemiesPerWave);
        }
       
    }

    
    void Update()
    {
        if (enableEnemies)
        {
            List<GameObject> enemiesKilled = new List<GameObject>();
            foreach (GameObject enemy in enemies)
            {
                if (!enemy.activeSelf)
                {
                    enemiesKilled.Add(enemy);
                }
            }

            foreach (GameObject enemy in enemiesKilled)
            {
               enemies.Remove(enemy);
               enemyWave--;
            }

            if (enemyWave == 0)
            {
                GameData.currentTime = 7 + 5 * enemiesPerWave;
                enemiesPerWave++;
                numberOfWaves--;
                enemiesKilled.Clear();
                enemies.Clear();
                SpawnEnemies(enemiesPerWave);
           
            }

          
        }
        
    }

    Vector3 CreateSpawn()
    {
        //On crée une vecteur de direction avec un angle random (entre 0 et 360deg) autour du joueur
        Vector3 direction = transform.forward;
        direction = Quaternion.AngleAxis(random.Next(0, random.Next(0, random.Next(0,360))), Vector3.up) * direction;

        //On crée une raie qui part du joueur vers la direction crée précédemment
        Ray ray = new Ray(transform.position, direction);
        //On choisit un point au hasard (entre minRadius et maxRadius) sur cette raie pour y faire spawner la cible
        return ray.GetPoint(random.Next(minDistance, maxDistance));
    }

    void SpawnEnemies(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 spawn = CreateSpawn();

            GameObject enemy = Instantiate<GameObject>(enemyPrefab);
            enemy.transform.localPosition = spawn;
            enemy.transform.localPosition = new Vector3(enemy.transform.position.x, 6, enemy.transform.position.z);
            enemy.transform.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
            enemy.transform.LookAt(transform);

            Checkspawn(enemy.transform);

            enemies.Add(enemy);
            enemyWave++;

            
        }
        

    }

    void Checkspawn(Transform enemy)
    {
        foreach (GameObject badEnemy in enemies)
        {
            if (Vector3.Distance(enemy.localPosition, badEnemy.transform.position) < 5)
            {
                enemy.localPosition = CreateSpawn();
                Checkspawn(enemy.transform);
            }
        }
    }

    

}
