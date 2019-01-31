//Sert a faire que la camera suit le curseur
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerLookAt : MonoBehaviour
{
    public bool showCursor;   //si on voit le curseur ou pas;
    public float sensitivity; //Sensibilite de la souris
    
    void Start()
    {
        if (showCursor == false)
            Cursor.visible = false; //Cacher le cursor

        //this.transform.localEulerAngles.y -= 153.372f;
    }

    
    void Update()
    {
        float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        float newRotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivity;

        this.transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);
    }
}
