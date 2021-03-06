﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class destroyCubeTest : MonoBehaviour
{
        
    private IEnumerator coroutine;//S'execute en paralele
    public float force = 3000.0f;//La force de l'impact
    public int returnedScore;

    private void Update()
    {
        Cursor.visible = false;
    }

    //S'execute quand la fleche touche a la cible
    public void OnCollisionOfChild(Collision collision,int score)
    {
        returnedScore = score;

        //Unity calcule la direction de la collision
        Vector3 dir = collision.contacts[0].point - transform.position;
          
        //Le block ne peut arreter la fleche la force oposee est maintenant de 1
        dir = -dir.normalized;

        //La direction fois la force donne le pushback
        GetComponent<Rigidbody>().AddForce(dir * force);
        
        //Verifier si la target est bel et bien touche par une fleche et non par le sol
       
        
            Debug.Log("allo");
            //La flèche colle au cube 
            collision.gameObject.transform.SetParent(this.transform, true);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);

            if (GameData.marathon == true)
            {
                Debug.Log("Target Hit");
                GameData.ammoArrow = 3;
            }

            if (GameData.hunt == true)
            {
                Debug.Log("test");
                GameData.ammoArrow = 4;
            }

            coroutine = cubeCollision(3);
            StartCoroutine(coroutine);
        
    }
    
    //La fonction qui fait attendre un certain nombre de temps
    private IEnumerator cubeCollision(int time)
    {
    
        GameData.test = 1;
        yield return new WaitForSeconds(time);
        //On desactive le gameObject
        gameObject.SetActive(false);
        
    }
}
