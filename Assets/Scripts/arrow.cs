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
    private float windForce = 1f;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(body.velocity); 

    }
    void FixedUpdate()
    {

        body.AddForce(wind/Mathf.Sqrt(Mathf.Pow(wind.x,2)+Mathf.Pow(wind.z,2))* windForce);
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
            AudioManager.instance.Play("Hit");
            timer = 0f;
        }
        
    }

    private void Stick()
    {
        body.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void setWindVector(float x, float y ,float z,float force)
    {
        wind.x = x;
        wind.y = y;
        wind.z = z;
        windForce = force;
    }
    public Vector3 getWindVector()
    {
        return wind;
    }
}
