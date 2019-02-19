using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 } //list de variable pour choisir on tourne sur quel axe
    public RotationAxes axes = RotationAxes.MouseXAndY; // On met la rotation pour dans les 2 axes
    public float sensX = 15F; //Sensibilite en x
    public float sensY = 15F; //Sensibilite en y

    //Maximum et min droit et gauche de la camera
    public float minX = -180F; 
    public float maxX = 180F;

    //Max et min de haut en bas
    public float minY = -60F; 
    public float maxY = 60F;

    //Mettre la rotation initial a 0
    float rotX = 0F;
    float rotY = 0F;

    //Les valeurs de rotX et rotY seront ajoute a ces list 
    //Aussi on initialise les moyennes de rotation a 0
    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F;

    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;

    //Limite a 20 le nombre de valeurs de rotX et rotY qui peuvent etre mit dans les rotArray
    public float frameCounter = 20;

    //Cest dure a comprendre mais cest avec Quaternion que tout les rotation seront applique
    Quaternion originalRotation;

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
          

            //Get l'input de la souris
            rotY += Input.GetAxis("Mouse Y") * sensY;
            rotX += Input.GetAxis("Mouse X") * sensX;

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
                rotAverageY += rotArrayY[j];
            }
            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }

            //calcul de la moyenne
            rotAverageY /= rotArrayY.Count;
            rotAverageX /= rotArrayX.Count;

            rotAverageY = ClampAngle(rotAverageY, minY, maxY);
            rotAverageX = ClampAngle(rotAverageX, minX, maxX);

            //Ca tourne
            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }

        
    
   public static float ClampAngle (float angle,float min, float max)
    {
        return Mathf.Clamp(angle, min, max);
    }
}
