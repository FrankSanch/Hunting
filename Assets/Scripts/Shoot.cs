using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;

    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = 100;
    private Random random = new Random();

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timer;
    private const float shootPowerIncrease = 0.5f;

    void Start()
    {
        //Le vent en x en y et en z est un nombre aléatoire entre 1 et 4
        if (GameData.windOn)
            windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity), random.Next(minWindVelocity, maxWindVelocity), random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTime)
        {
            if (Input.GetMouseButton(0) && shootPower <= 60)
            {


                shootPower += shootPowerIncrease;
            }

            if (Input.GetMouseButtonUp(0))
            {
                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);
                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrowClone.name = "arrow";

                rigidbodycomponent.velocity = cam.transform.forward * shootPower + windVelocity ;

                shootPower = 3f;
                timer = 0f;
            }
            
        }
        
    }
}
