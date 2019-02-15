using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowModele;
    public Transform arrowspawn;
    public float shootpower = 20f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrowClone = Instantiate(arrowModele, arrowspawn.position, Quaternion.identity);
            Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
            rigidbodycomponent.velocity = cam.transform.forward * shootpower;

        }
    }
}
