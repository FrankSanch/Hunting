using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class enemySpawner : MonoBehaviour
{

    private List<GameObject> enemies = new List<GameObject>();
    
   

    private bool enableEnemies = GameData.enemyOn;

    private Random random;

    public GameObject enemyPrefab;

    public float enemyScale = 3f;

    public int enemyWave = 0;
    public int numberOfWaves = 3;
    private int enemiesPerWave = 1;



    //distance maximal et minimal pour faire apparaître les enemies
    private int maxDistance = 20;
    private int minDistance = 10;

    void Start()
    {
        if (enableEnemies)
        {
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
            for (int i = 0; i < enemiesPerWave; i++)
            {
                if (!enemies[i].activeSelf)
                {
                    enemiesKilled.Add(enemies[i]);
                }

            }

            foreach (GameObject enemy in enemiesKilled)
            {
               enemies.Remove(enemy);
               enemyWave--;
            }

            if (enemyWave == 0)
            {
                enemiesPerWave++;
                numberOfWaves--;
                SpawnEnemies(enemiesPerWave);
            }

          
        }
        
    }

    Vector3 CreateSpawn()
    {
        //On crée une vecteur de direction avec un angle random (entre 0 et 360deg) autour du joueur
        Vector3 direction = transform.forward;
        direction = Quaternion.AngleAxis(random.Next(0, 360), Vector3.up) * direction;

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
            if (Vector3.Distance(enemy.localPosition, badEnemy.transform.position) < enemyScale)
            {
                enemy.localPosition = CreateSpawn();
                Checkspawn(enemy.transform);
            }
        }
    }

}
