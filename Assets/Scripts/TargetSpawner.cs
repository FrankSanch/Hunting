using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class TargetSpawner : MonoBehaviour
{
    public GameObject bow;
    
    private bool canMove = false;

    public int targetCountInitial = 5;
    private int targetCount;
    private List<GameObject> targets = new List<GameObject>();
    private List<float> mvtSpeeds = new List<float>();
    private float targetScale = 10;
    public GameObject targetPrefab;

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
        targetCount = targetCountInitial;

        for (int i = 0; i < targetCountInitial; i++)
        {
            Vector3 spawn = CreateSpawn();

            GameObject target = Instantiate<GameObject>(targetPrefab);
            //target.GetComponent<Collider>().isTrigger = true;
            target.transform.localPosition = spawn;
            target.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            target.transform.LookAt(transform);

            Checkspawn(target.transform);

            if (canMove)
            {
                float speed = random.Next(minSpeed, maxSpeed); // * (1 / Vector3.Distance(target.transform.position, transform.position));
                if(i%2 == 0)
                {
                    speed = -speed;
                }

                mvtSpeeds.Add(speed);
            }
            targets.Add(target);
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
    void Checkspawn(Transform target)
    {
        foreach (GameObject oldTarget in targets)
        {
            if(Vector3.Distance(target.localPosition, oldTarget.transform.position) < targetScale)
            {
                target.localPosition = CreateSpawn();
                Checkspawn(target.transform);
            }
        }
    }

    void Update()
    {
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
            targets.Remove(target);
            Destroy(target);
            Shoot shootComponent = bow.GetComponent<Shoot>();
            shootComponent.changeWind();
            targetCount--;
        }
        if(targetCount == 0)
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}