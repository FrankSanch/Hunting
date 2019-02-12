using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody body;
    private float lifeTime = 2f;
    private float timer;
    private bool hitsomething = false;

    void Start()
    {
        

        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(body.velocity);

    }

    // Update is called once per frame
    void Update()
    {
        if (hitsomething==false)
        {
            transform.rotation = Quaternion.LookRotation(body.velocity);
        }
            
    }

    private void OnCollision(Collision collision)
    {
        hitsomething = true;
    }

    private void Stick()
    {
        body.constraints = RigidbodyConstraints.FreezeAll;
    }
}
