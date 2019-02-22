using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeControler : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float soundVolume = 1.0f;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = soundVolume;
    }
}
