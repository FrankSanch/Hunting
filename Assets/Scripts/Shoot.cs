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
    private const float MaxShootpower = 60f;
    private float shootTime = 0.5f;
    private float timeStart = 0f;
    private float timer;
    private float timeInterval = 0f;
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


        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windArrows.transform.rotation = Quaternion.Euler(0, angleWind, 0); //indique la direction du vent sur le UI
        
       
        windspeedText.SetText((windSpeed*3.6).ToString("0") + "Km/h"); //affiche la vitesse du vent en km/h

        animator = GetComponent<Animator>();


    }

    void Update()
    {

        
        
        timer = Time.time;
        timeInterval += Time.deltaTime;
        
       
        if (timeInterval >= shootTime && GameData.ammoArrow > 0) //Ajoute un interval de temps entre chaque fleches
        {
            if(Input.GetMouseButtonDown(0))
            {
                timeStart = Time.time;
                shotMade = true;

            }
            if (Input.GetMouseButton(0) && timer-timeStart <= 1)
            {
                

                shootPower = MaxShootpower*((timer-timeStart)+0.1f); //augmente le shoot power a mesure que le bouton est enfonce
                mainSlider.value = shootPower; // Affiche le power sur le UI avec un slider
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

                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity); //cree la fleche

                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                Vector2 HorizontalWind = new Vector2(windVelocity.x,windVelocity.z);  //donne le vecteur horinzontale du vent
                Vector2 HorizontalArrow = new Vector2(cam.transform.forward.x, cam.transform.forward.z); //donne le vecteur horizontale de la direction de la fleche

                angleBetweenWindArrow =Vector2.Angle(HorizontalWind, HorizontalArrow); //angle horizontal entre vent et fleche
                SetWindForce();               
                arrowComponent.setWindVector(windVelocity.x, windVelocity.y, windVelocity.z,windForce);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower; //lance la fleche dans la direction de la camera avec le shoot power
                

                shootPower = 3f;
                timer = 0f;
                timeInterval = 0f;

                mainSlider.value = shootPower;

                
                GameData.ammoArrow--;

               

                animator.SetFloat("Power", shootPower-3);
                animator.SetBool("Shot", false);
                //Debug.Log("2");
                shotMade = false;
                AudioManager.instance.Play("ClickSound");
            }

        }

        windArrows.transform.localRotation = Quaternion.Euler(0, angleWind - transform.root.rotation.eulerAngles.y, 0); // indique la direction du vent sur le UI


    }
    public void ChangeWind() //change la direction du vent et vitesse du vent
    {
        windVelocity = new Vector3(random.Next(minWindVelocity, maxWindVelocity), 0, random.Next(minWindVelocity, maxWindVelocity)) * 0.01f;
        windSpeed = random.Next(0, 25);
        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windspeedText.SetText((windSpeed * 3.6).ToString("0") + "Km/h");
    }
    void SetCx() //determine le coefficient de penetration dair en fonction de lorientation de la fleche par rapport au vent
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
    void SetSurfaceOfContact() //determine la surface de contact soumise au vent
    {
        surfaceOfContact = arrorDiameter * arrowLenght * Mathf.Sin(angleBetweenWindArrow * Mathf.PI / 180f);
    }

    void SetWindForce() //calcul la force du vent sur la fleche
    {
        SetCx();
        SetSurfaceOfContact();
        windForce = 0.5f * cx * rho * surfaceOfContact * windSpeed * windSpeed;
    }

   
    }


