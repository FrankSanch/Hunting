using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    public GameObject bow;
    
    private bool canMove = false;


    public int targetCountInitial = 5;
    private int targetCount = 0;
    public int remainingTargets = 5;


    private List<GameObject> targets = new List<GameObject>();
    private List<float> mvtSpeeds = new List<float>();

    private float targetScale = 3f;
    public GameObject targetPrefab;

    public int totalScore = 0;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text levelText;
    private Random random;

    //distance maximal et minimal pour faire apparaître les cibles
    private int maxDistance = 60;
    private int minDistance = 30;

    //vitesse maximal et minimal de pour la mouvement des cibles en deg/s
    private int maxSpeed = 20;
    private int minSpeed = 10;

    void Start()
    {
        canMove = GameData.targetMobileOn;
        random = new Random();

        SpawnTargets(1);
        levelText.SetText(GameData.level);
    }

    void SpawnTargets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawn = CreateSpawn();

            GameObject target = Instantiate<GameObject>(targetPrefab);
            //target.GetComponent<Collider>().isTrigger = true;
            target.transform.localPosition = spawn;
            target.transform.localPosition = new Vector3(target.transform.position.x, random.Next(10,20), target.transform.position.z);
            target.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            target.transform.LookAt(transform);

            //Checkspawn(target.transform);

            if (canMove)
            {
                float speed = random.Next(minSpeed, maxSpeed); // * (1 / Vector3.Distance(target.transform.position, transform.position));
                if (i % 2 == 0)
                {
                    speed = -speed;
                }

                mvtSpeeds.Add(speed);
            }

            targets.Add(target);
            targetCount++;
            remainingTargets--;
        }
    }

    Vector3 CreateSpawn()
    {
        //On crée une vecteur de direction avec un angle random (entre 0 et 360deg) autour du joueur
        Vector3 direction = transform.forward;
        direction = Quaternion.AngleAxis(random.Next(0, 360), Vector3.up) * direction;

        //On crée une raie qui part du joueur bers la direction crée précédemment
        Ray ray = new Ray(transform.position, direction);
        //On choisit un point au hasard (entre minRadius et maxRadius) sur cette raie pour y faire spawner la cible
        return ray.GetPoint(random.Next(minDistance, maxDistance));
    }

    //Verification de la position des cibles pour ne pas qu'elles se touchent
    /*void Checkspawn(Transform target)
    {
        foreach (GameObject oldTarget in targets)
        {
            if(Vector3.Distance(target.localPosition, oldTarget.transform.position) < targetScale)
            {
                target.localPosition = CreateSpawn();
                Checkspawn(target.transform);
            }
        }
    }*/

    void Update()
    {
        //retire les targets unactive du jeu 
        List<GameObject> targetsHit = new List<GameObject>();
        for (int i = 0; i < targetCount; i++)
        {
            if(!targets[i].activeSelf)
            {
                targetsHit.Add(targets[i]);
            }

            if (canMove)
            {
                targets[i].transform.RotateAround(transform.position, Vector3.up, mvtSpeeds[i] * Time.deltaTime);
                targets[i].transform.LookAt(transform);
            }
        }
        foreach (GameObject target in targetsHit)
        {
            destroyCubeTest destroyCubeTestComponent = target.GetComponent<destroyCubeTest>();

            totalScore += destroyCubeTestComponent.returnedScore;//Increment le score 

            targets.Remove(target);
            Destroy(target);

            Shoot shootComponent = bow.GetComponent<Shoot>();
            shootComponent.ChangeWind();
            targetCount--;
        }
        if(remainingTargets > 0 && targetCount < 1)
        {
            SpawnTargets(1);
        }

        if(targetCount == 0)
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);

        scoreText.SetText("Score : " + totalScore.ToString());
    }
}