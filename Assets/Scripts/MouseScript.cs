using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseScript : MonoBehaviour
{
   
    
    //Maximum et min droit et gauche de la camera
    public float minX = -360F; 
    public float maxX = 360;

    public float sensX = 5F; //Sensibilite en x
    public float sensY = 5F; //Sensibilite en y


    //Max et min de haut en bas
    public float minY = -60F; 
    public float maxY = 60F;

    //Mettre la rotation initial a 0
    float rotX = 0F;
    float rotY = 0F;

    float mouseXInput;
    float mouseYInput;

    //Les valeurs de rotX et rotY seront ajoute a ces list 
    //Aussi on initialise les moyennes de rotation a 0
    private List<float> rotArrayX = new List<float>();
    float rotMoyenneX = 0F;

    private List<float> rotArrayY = new List<float>();
    float rotMoyenneY = 0F;

    //Limite a 5 le nombre de valeurs de rotX et rotY qui peuvent etre mit dans les rotArray
    public float frameCounter = 1;

    //Cest dure a comprendre mais cest avec Quaternion que tout les rotation seront applique, On le set dans start
    Quaternion originalRotation;


    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.freezeRotation = true;
        }

        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }

        //On reset les rotation a chaque frame donc c'est pratiquement impossible de se rendre a 360 ou -360

        rotMoyenneX = 0;
        rotMoyenneY = 0;

        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

       // mouseXInput = mouseXInput * Mathf.Abs(mouseXInput);
        //mouseYInput = mouseYInput * Mathf.Abs(mouseYInput);


        //Get l'input de la souris mais smooth

        rotY += mouseYInput * sensY;

        rotX += mouseXInput * sensX;

        rotArrayY.Add(rotY);
        rotArrayX.Add(rotX);

        if (rotArrayY.Count >= frameCounter)
        {
            rotArrayY.RemoveAt(0);
        }
        if (rotArrayX.Count >= frameCounter)
        {
            rotArrayX.RemoveAt(0);
        }
            // On ajoute toutes les rotations avant de faire leur moyenne en x et y
        for (int j = 0; j < rotArrayY.Count; j++)
        {
            rotMoyenneY += rotArrayY[j];
        }
        for (int i = 0; i < rotArrayX.Count; i++)
        {
            rotMoyenneX += rotArrayX[i];
        }

        //calcul de la moyenne
        rotMoyenneY /= rotArrayY.Count;
        rotMoyenneX /= rotArrayX.Count;

        rotMoyenneY = View(rotMoyenneY, minY, maxY);
        rotMoyenneX = View(rotMoyenneX, minX, maxX);

        //Ca tourne
        Quaternion yQuaternion = Quaternion.AngleAxis(rotMoyenneY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotMoyenneX, Vector3.up);

        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
       
    }

   



     float View(float rotation, float min, float max)
    {
        rotation = rotation % 360;

        if (rotation >= 360 || rotation <= -360)
            rotation = 0;

        return Mathf.Clamp(rotation, min, max);
    }
}
