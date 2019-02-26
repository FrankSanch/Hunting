using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;

    

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timer;
    private const float shootPowerIncrease = 0.5f;

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
                rigidbodycomponent.velocity = cam.transform.forward * shootPower;
                shootPower = 3f;
                timer = 0f;
            }
            
        }
        
    }
}
