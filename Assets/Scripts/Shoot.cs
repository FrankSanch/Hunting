using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;
    private float shootpower = 1f;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            shootpower++;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);
            Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
            arrowClone.name = "arrow";
            rigidbodycomponent.velocity = cam.transform.forward * shootpower;
            shootpower = 1f;

        }
    }
}
