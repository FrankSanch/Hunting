using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    Rigidbody body;

    private float lifeTime = 3f;

    private float timer;
    private bool hitsomething = false;
    private Vector3 wind;

    GameObject Gamedataboy;
    void Start()
    {
        Gamedataboy = GameObject.Find("Gamedata");
        wind = new Vector3();
        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(body.velocity);
        
    }
    void FixedUpdate()
    {

        body.AddForce(wind * 10);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeTime && hitsomething)
        {
            Destroy(gameObject);
        }
        if (!hitsomething)
        {
            transform.rotation = Quaternion.LookRotation(body.velocity);
        }
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
    public void setVector(float x, float y ,float z)
    {
        wind.x = x;
        wind.y = y;
        wind.z = z;
    }
}
