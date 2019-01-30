using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    private GameObject bowMiddle;
    private GameObject bowTop;

   
    void Start()
    {
        bowMiddle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui servira de manche pour l'arc
        bowMiddle.transform.SetParent(this.transform, false);
        bowMiddle.transform.localPosition = new Vector3(0, 0, 0);
        bowMiddle.transform.localScale = new Vector3((float)0.03, (float)0.3, (float)0.02);

        bowTop = GameObject.CreatePrimitive(PrimitiveType.Cylinder);   //Initialiser un cylindre qui servira de manche pour l'arc
        bowTop.transform.SetParent(this.transform, false);
        bowTop.transform.localPosition = new Vector3(0, 0, 0);
        bowTop.transform.localScale = new Vector3((float)0.03, (float)0.3, (float)0.02);
        bowTop.transform.localRotation = Quaternion.AngleAxis(30, Vector3.left);

    }

   
    void Update()
    {
        
    }
}
