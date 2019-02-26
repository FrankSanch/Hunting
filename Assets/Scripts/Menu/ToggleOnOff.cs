using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOff : MonoBehaviour
{
    bool isMute;
    public GameObject audioSource;
    bool soundToggle = true;
    bool musicToggle = true;
    bool masterToggle = true;

    public void MuteMusic()
    {
        if (masterToggle == false)
        {
        }
        else
        {
            musicToggle = !musicToggle;
            if (musicToggle)
            {
                audioSource.SetActive(true);
                
            }
            else
            {
                audioSource.SetActive(false);
            }
       }
    }

    public void MuteSound()
    {
        if (masterToggle == false)
        {
        }
        else
        {
            soundToggle = !soundToggle;
            if (soundToggle)
            {
                audioSource.SetActive(true);
            }
            else
            {
                audioSource.SetActive(false);
            }
        }
    }

    public void MuteMaster()
    {
      //masterToggle = !masterToggle;
        if (soundToggle == false & musicToggle == false)
        {
        }
        else
        {
            masterToggle = !masterToggle;
            //soundToggle = !soundToggle;
            //musicToggle = !musicToggle;
            if (masterToggle)
            {
                audioSource.SetActive(true);
                //audioSource.mute = true;
                //audioSource.volume = 1.0f;
            }
            else
            {
                audioSource.SetActive(false);
                //audioSource.mute = false;
                //audioSource.volume = 0.0f;
            }

        }
    }



    /*OnGUI()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            audioSource.SetActive(true);
            //audioSource.mute = true;
            //audioSource.volume = 1.0f;
        }
        else
        {
            audioSource.SetActive(false);
            //audioSource.mute = false;
            //audioSource.volume = 0.0f;
        }
    }*/
}
