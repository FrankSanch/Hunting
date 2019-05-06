using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setArrow : MonoBehaviour
{
    private TMPro.TMP_Text numberOfArrows;
   

    void Start()
    {
        numberOfArrows = GetComponent<TMPro.TMP_Text>();
        numberOfArrows.SetText("Arrows: " + GameData.ammoArrow);
        
    }


    void Update()
    {
        numberOfArrows.SetText("Arrows: " + GameData.ammoArrow);

        if(GameData.ammoArrow == 0)
        {
            StartCoroutine(ammoCheck(2));
        }
    }

    private IEnumerator ammoCheck(int time)
    {
        yield return new WaitForSeconds(time);
       
        
        if(GameData.ammoArrow == 0)
            Cursor.visible = true;
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }
}
