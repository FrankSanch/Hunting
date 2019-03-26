using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;
    public arrow yolo;

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timer;
    private const float shootPowerIncrease = 0.5f;

    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = -400;
    private Random random = new Random();

    void Start()
    {
        changeWind();
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
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                arrowComponent.setVector(windVelocity.x, windVelocity.y, windVelocity.z);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower ;

                shootPower = 3f;
                timer = 0f;
            }
            
        }
        
    }
    public void changeWind()
    {
        //windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity),0, random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
    }
}
