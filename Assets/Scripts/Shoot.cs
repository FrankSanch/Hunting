using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    private IEnumerator coroutine;
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timeStart = 0f;
    private float timer;
    private float timeInterval = 0f;
    private const float shootPowerIncrease = 0.5f;
    private bool shotMade= false;
    public Vector3 windVelocity = Vector3.zero;
    private int maxWindVelocity = 400;
    private int minWindVelocity = -400;
    private Random random = new Random();

    public Slider mainSlider;

    public GameObject windArrows;
    public float angleWind;
    public float vectorWind;
    

    
    public TMPro.TMP_Text windspeedText;

    public Animator animator;

    float angleBetweenWindArrow = 0f;
    float surfaceOfContact = 0f;
    const float arrorDiameter = 0.0091281f;
    const float arrowLenght = 0.70f;
    const float rho = 1.29f;
    float windForce = 1f;
    float cx = 0;

    float windSpeed;
    float test;
    void Start()
    {
        ChangeWind();

        //vectorwind = Mathf.Sqrt(Mathf.Pow(windVelocity.x, 2f) + Mathf.Pow(windVelocity.z, 2f));

        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windArrows.transform.rotation = Quaternion.Euler(0, angleWind, 0);
        
       
        windspeedText.SetText((windSpeed*3.6).ToString("0") + "Km/h");

        animator = GetComponent<Animator>();


    }

    void Update()
    {

        
        
        timer = Time.time;
        timeInterval += Time.deltaTime;
        windspeedText.SetText((windSpeed * 3.6).ToString("0") + "Km/h");
       
        if (timeInterval >= shootTime && GameData.ammoArrow > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                timeStart = Time.time;
                shotMade = true;

            }
            if (Input.GetMouseButton(0) && timer-timeStart <= 1)
            {
                

                shootPower = 60*((timer-timeStart)+0.1f);
                mainSlider.value = shootPower;
                animator.SetFloat("Power", shootPower);
                animator.SetBool("Shot", true);
                //Debug.Log(shootPower.ToString());
                if (shootPower > 60)
                {
                    animator.SetBool("Shot", false);
                }


            }

            if (Input.GetMouseButtonUp(0) && shotMade)
            {

                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);

                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                Vector2 HorizontalWind = new Vector2(windVelocity.x,windVelocity.z);
                Vector2 HorizontalArrow = new Vector2(cam.transform.forward.x, cam.transform.forward.z);

                angleBetweenWindArrow =Vector2.Angle(HorizontalWind, HorizontalArrow);
                SetWindForce();               
                arrowComponent.setWindVector(windVelocity.x, windVelocity.y, windVelocity.z,windForce);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower;
                

                shootPower = 3f;
                timer = 0f;
                timeInterval = 0f;

                mainSlider.value = shootPower;

                
                GameData.ammoArrow--;

               

                animator.SetFloat("Power", shootPower-3);
                animator.SetBool("Shot", false);
                //Debug.Log("2");
                shotMade = false;
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
    public void ChangeWind()
    {
        windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity), 0, random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
        windSpeed = random.Next(0, 25);
        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
    }
    void SetCx()
    {
        if (angleBetweenWindArrow <= 5)
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
    }
    void SetSurfaceOfContact()
    {
        surfaceOfContact = arrorDiameter * arrowLenght * Mathf.Sin(angleBetweenWindArrow * Mathf.PI / 180f);
    }

    void SetWindForce()
    {
        SetCx();
        SetSurfaceOfContact();
        windForce = 0.5f * cx * rho * surfaceOfContact * windSpeed * windSpeed;
    }

   
    }


