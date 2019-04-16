using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timer;
    private const float shootPowerIncrease = 0.5f;

    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = -400;
    private Random random = new Random();

    public Slider mainSlider;

    public GameObject windArrows;
    public float angleWind;
    public float vectorWind;


    void Start()
    {
        changeWind();


        //vectorwind = Mathf.Sqrt(Mathf.Pow(windVelocity.x, 2f) + Mathf.Pow(windVelocity.z, 2f));

        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windArrows.transform.rotation = Quaternion.Euler(0, angleWind, 0);

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTime)
        {
            if (Input.GetMouseButton(0) && shootPower <= 60)
            {


                shootPower += shootPowerIncrease;
                mainSlider.value = shootPower;
            }

            if (Input.GetMouseButtonUp(0))
            {

                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);

                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                arrowComponent.setVector(windVelocity.x, windVelocity.y, windVelocity.z);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower;

                shootPower = 3f;
                timer = 0f;
                mainSlider.value = shootPower;
                
            }

        }

        windArrows.transform.localRotation = Quaternion.Euler(0, angleWind - transform.root.rotation.eulerAngles.y, 0);

        /*
        if(transform.root.rotation.eulerAngles.y > 0)
        {
            windArrows.transform.localRotation = Quaternion.Euler(0,vectorVent + transform.root.rotation.eulerAngles.y, 0);
        }
        if (transform.root.rotation.eulerAngles.y < 0)
        {
            windArrows.transform.localRotation = Quaternion.Euler(0,vectorVent +transform.root.rotation.eulerAngles.y, 0);
        }*/


    }
    public void changeWind()
    {
        windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity), 0, random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
    }

}
