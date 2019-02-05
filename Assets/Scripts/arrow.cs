using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody body;
    private float lifeTimer = 2f;
    private float timer;
    private bool hitsomething = false;

    void Start()
    {
        //je veux voir si mes commits fonctionnent
        //MOER TOOO!
        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(body.velocity);

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(body.velocity);
    }
}
