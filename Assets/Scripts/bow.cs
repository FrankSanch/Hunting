using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    private GameObject bowMiddle;//milieu de l'arc
    private GameObject bowTop;//top de l'arc
    private GameObject bowBot; //bas de l'arc


   
    void Start()
    {
        bowMiddle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui servira de manche pour le milieu de l'arc.
        bowMiddle.transform.SetParent(this.transform, false);
        bowMiddle.transform.localPosition = new Vector3(0, 0.5f, -0.5f);
        bowMiddle.transform.localScale = new Vector3(0.03f, 0.12f, 0.02f);
        bowMiddle.name = "BowMiddle";

        bowMiddle.GetComponent<CapsuleCollider>().isTrigger = true; // sets istrigger to avoid collision with the ground

        bowTop = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui sera la partie superieur du manche de l'arc
        bowTop.transform.SetParent(this.transform, false);  
        bowTop.transform.localScale = new Vector3(0.03f, 0.3f, 0.02f);
        bowTop.transform.localRotation = Quaternion.AngleAxis(30, Vector3.left);
        bowTop.transform.localPosition = new Vector3(0, 0.875f, -0.65f);
        bowTop.name = "BowTop";

        bowTop.GetComponent<CapsuleCollider>().isTrigger = true;

        bowBot = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui sera la partie inferieur du manche de l'arc
        bowBot.transform.SetParent(this.transform, false);
        bowBot.transform.localScale = new Vector3(0.03f, 0.3f, 0.02f);
        bowBot.transform.localRotation = Quaternion.AngleAxis(30, Vector3.right);
        bowBot.transform.localPosition = new Vector3(0, 0.125f, -0.65f);
        bowBot.name = "BowBot";

        bowBot.GetComponent<CapsuleCollider>().isTrigger = true;
        
    }


    void Update()
    {
        
    }
}
