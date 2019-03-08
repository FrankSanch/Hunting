using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody body;
    private float lifeTime = 3f;
    private float timer;
    private bool hitsomething = false;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(body.velocity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeTime && hitsomething)
        {
            Destroy(gameObject);
        }
        //J'ai trouvé un meilleur moyen pour coller la flèche (destroyCubeTest.cs)
        /*if (!hitsomething)
        {
            transform.rotation = Quaternion.LookRotation(body.velocity);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Arrow")
        {
            hitsomething = true;
            Stick();
            timer = 0f;
        }
        
    }

    private void Stick()
    {
        body.constraints = RigidbodyConstraints.FreezeAll;
    }
}
