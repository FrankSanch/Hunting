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
    private float timeStart = 0f;
    private float timer;
    private float timeInterval = 0f;
    private const float shootPowerIncrease = 0.5f;

    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = -400;
    private Random random = new Random();

    public Slider mainSlider;

    public GameObject windArrows;
    public float angleWind;
    public float vectorWind;
    public int localAmmo;

    public TMPro.TMP_Text arrowText;

    public Animator animator;

    float angleBetweenWindArrow = 0f;
    float surfaceOfContact = 0f;
    float windForce = 1f;
    float cx = 0;
    float windSpeed;
    float test;
    void Start()
    {
        changeWind();

        //vectorwind = Mathf.Sqrt(Mathf.Pow(windVelocity.x, 2f) + Mathf.Pow(windVelocity.z, 2f));

        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windArrows.transform.rotation = Quaternion.Euler(0, angleWind, 0);
        localAmmo = GameData.ammoArrow;
        arrowText.SetText("Arrows x" + windSpeed.ToString());

        animator = GetComponent<Animator>();


    }

    void Update()
    {
        
        timer = Time.time;
        timeInterval += Time.deltaTime;
        if(localAmmo==0)
        {
            Debug.Log("J'AI PU DE FLÈCHE");
            localAmmo--;
        }

      /*  if (timeInterval >= shootTime)
        {*/
            if(Input.GetMouseButtonDown(0))
            {
                timeStart = Time.time;
            }
            if (Input.GetMouseButton(0) && timer-timeStart <= 1)
            {
                

                shootPower = 60*((timer-timeStart)+0.1f);
                mainSlider.value = shootPower;
                animator.SetFloat("Power", shootPower);
                animator.SetBool("Shot", true);
                Debug.Log(shootPower.ToString());
                if (shootPower > 60)
                {
                    animator.SetBool("Shot", false);
                }


            }

            if (Input.GetMouseButtonUp(0))
            {

                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);

                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                Vector2 HorizontalWind = new Vector2(windVelocity.x,windVelocity.z);
                Vector2 HorizontalArrow = new Vector2(cam.transform.forward.x, cam.transform.forward.z);

                angleBetweenWindArrow =Vector2.Angle(HorizontalWind, HorizontalArrow);
                if(angleBetweenWindArrow <= 5)
                {
                    cx = 0.1f;
                }
                else if (angleBetweenWindArrow > 5 && angleBetweenWindArrow < 175)
                 {
                     cx = 0.82f;
                 }
                else if (angleBetweenWindArrow >= 175)
                {
                    cx = 0.4f;
                }
                surfaceOfContact = 0.0091281f * 0.70f * Mathf.Sin(angleBetweenWindArrow * 3.1416f / 180f);
                windForce = 0.5f * cx * 1.29f * surfaceOfContact * windSpeed*windSpeed;
                arrowComponent.setWindVector(windVelocity.x, windVelocity.y, windVelocity.z,windForce);
                test = Mathf.Sin(angleBetweenWindArrow*3.1416f/180f);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower;
 
                shootPower = 3f;
                timer = 0f;
                timeInterval = 0f;
                mainSlider.value = shootPower;
                localAmmo--;
                arrowText.SetText("Arrows x" + windSpeed.ToString());

                animator.SetFloat("Power", shootPower-3);
                animator.SetBool("Shot", false);
                //Debug.Log("2");

            }

        //}

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
        windSpeed = random.Next(0, 25);
        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
    }

}
