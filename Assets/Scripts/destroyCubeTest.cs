﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyCubeTest : MonoBehaviour
{
    
    private IEnumerator coroutine;//S'execute en paralele
    public float force = 3000.0f;//La force de l'impact
   
    void Start()
    {
        float collisionCounter = 1.0f;
    }
  

    //S'execute quand la fleche touche a la cible
    private void OnCollisionEnter(Collision collision)
    {
   
        //Unity calcule la direction de la collision
        Vector3 dir = collision.contacts[0].point - transform.position;
          
        //Le block ne peut arreter la fleche la force oposee est maintenant de 1
        dir = -dir.normalized;

        //La direction fois la force donne le pushback
        GetComponent<Rigidbody>().AddForce(dir * force);
        
        //Verifier si la target est bel et bien touche par une fleche et non par le sol
       if(collision.gameObject.name == "arrow")
        {
            collision.gameObject.transform.SetParent(this.transform, true);
            //collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collisionCounter++;

            coroutine = cubeCollision(1);
            StartCoroutine(coroutine);

            if(collisionCounter == 2)
            {
                coroutine = cubeCollision(6);
                StartCoroutine(coroutine);
                SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
            }
        }

    }
    

    

    //La fonction qui fait attendre un certain nombre de temps
    private IEnumerator cubeCollision(int time)
        {

        yield return new WaitForSeconds(time);
        //On detruit le gameObject
        Destroy(this.gameObject);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
