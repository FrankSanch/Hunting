using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    public GameObject bowMiddle;//milieu de l'arc
    public GameObject bowTop;//top de l'arc
    private GameObject bowBot; //bas de l'arc


   
    void Start()
    {
        bowMiddle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui servira de manche pour le milieu de l'arc.
        bowMiddle.transform.SetParent(this.transform, false);
        bowMiddle.transform.localPosition = new Vector3(0, (float)0.5, 0);
        bowMiddle.transform.localScale = new Vector3((float)0.03, (float)0.12, (float)0.02);

        bowMiddle.GetComponent<CapsuleCollider>().isTrigger = true; // sets istrigger to avoid collision with the ground

        bowTop = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui sera la partie superieur du manche de l'arc
        bowTop.transform.SetParent(this.transform, false);  
        bowTop.transform.localScale = new Vector3((float)0.03, (float)0.3, (float)0.02);
        bowTop.transform.localRotation = Quaternion.AngleAxis(30, Vector3.left);
        bowTop.transform.localPosition = new Vector3(0, (float)0.875, (float)-0.15);

        bowTop.GetComponent<CapsuleCollider>().isTrigger = true;

        bowBot = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui sera la partie inferieur du manche de l'arc
        bowBot.transform.SetParent(this.transform, false);
        bowBot.transform.localScale = new Vector3((float)0.03, (float)0.3, (float)0.02);
        bowBot.transform.localRotation = Quaternion.AngleAxis(30, Vector3.right);
        bowBot.transform.localPosition = new Vector3(0, (float)0.125, (float)-0.15);

        bowBot.GetComponent<CapsuleCollider>().isTrigger = true;

    }


    void Update()
    {
        
    }
}
