using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cible : MonoBehaviour
{
    public GameObject completeTarget;
    
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag=="Arrow")
        {
            destroyCubeTest destroyComponent = completeTarget.GetComponent<destroyCubeTest>();
            destroyComponent.OnCollisionOfChild(collision,int.Parse(this.name)); // indique quelle partie de la cible a ete atteinte et lenvoie a la grosse cible
        }
       
    }
}
