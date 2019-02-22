using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeControler : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float musicVolume = 1.0f;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = musicVolume;
    }
}
