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

        this.sensitivity = 1.0f;
    }

    
    void Update()
    {
        /*float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        float newRotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivity;

        this.transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);
         */
        float x = Input.GetAxis("Mouse X") * sensitivity;
        float y = Input.GetAxis("Mouse Y") * sensitivity;
        this.transform.Rotate(y, x, 0);
    }
}
