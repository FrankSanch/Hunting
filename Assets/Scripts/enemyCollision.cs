﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    private IEnumerator coroutine;//S'execute en paralele
    public float force = 3000.0f;//La force de l'impact
    

    //S'execute quand la fleche touche a la cible
    public void OnCollisionEnter(Collision collision)
    {
        //Verifier si la target est bel et bien touche par une fleche et non par le sol
        if (collision.gameObject.name == "arrow")
        {
            GameData.huntScore += 10;
            Debug.Log(GameData.totalScore);
            if (GameData.marathon)
            {
                Debug.Log("Target Hit");
                GameData.ammoArrow = 3;
            }

            if (GameData.hunt)
            {
                Debug.Log("test");
                GameData.ammoArrow = 4;
            }

            collision.gameObject.transform.SetParent(this.transform, true);

            coroutine = enemyHit(2);
            StartCoroutine(coroutine);

        }
    }

    //La fonction qui fait attendre un certain nombre de temps
    private IEnumerator enemyHit(int time)
    {
        yield return new WaitForSeconds(time);
        //On desactive le gameObject
        gameObject.SetActive(false);
    }
}

