using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}

