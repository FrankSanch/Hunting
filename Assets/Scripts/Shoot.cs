using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowspawn;

    private float shootPower = 3f;
    private float shootTime = 1f;
    private float timeStart = 0f;
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
    

    public TMPro.TMP_Text arrowText;

    public Animator animator;

   float angleBetweenWindArrow = 0f;
    float surfaceOfContact = 0f;


    void Start()
    {
        changeWind();


        GameData.arrowMissed = 0;


        //vectorwind = Mathf.Sqrt(Mathf.Pow(windVelocity.x, 2f) + Mathf.Pow(windVelocity.z, 2f));

        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
        windArrows.transform.rotation = Quaternion.Euler(0, angleWind, 0);
        
        
        animator = GetComponent<Animator>();


    }

    void Update()
    {

        timer += Time.deltaTime;
        



        if (timer >= shootTime)
        {
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
                Debug.Log("Shoot");
                GameObject arrowClone = Instantiate(arrowPrefab, arrowspawn.position, Quaternion.identity);

                Rigidbody rigidbodycomponent = arrowClone.GetComponent<Rigidbody>();
                arrow arrowComponent = arrowClone.GetComponent<arrow>();
                arrowClone.name = "arrow";
                Vector2 HorizontalWind = new Vector2(windVelocity.x,windVelocity.z);
                Vector2 HorizontalArrow = new Vector2(cam.transform.forward.x, cam.transform.forward.z);

                angleBetweenWindArrow =Vector2.Angle(HorizontalWind, HorizontalArrow);
                surfaceOfContact = 0.0091281f * 0.70f * Mathf.Sin(angleBetweenWindArrow);

                arrowComponent.setVector(windVelocity.x, windVelocity.y, windVelocity.z);
                rigidbodycomponent.velocity = cam.transform.forward * shootPower;

                shootPower = 3f;
                timer = 0f;
                mainSlider.value = shootPower;


               
                GameData.arrowMissed++;
                GameData.ammoArrow--;
                Debug.Log(GameData.arrowMissed);
                
                

               

                animator.SetFloat("Power", shootPower-3);
                animator.SetBool("Shot", false);
                //Debug.Log("2");


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
        angleWind = Mathf.Atan2(windVelocity.x, windVelocity.z) * Mathf.Rad2Deg;
    }

}
