using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    public AudioSource AudioGamePlay;

    void Update()
    {
        if (AudioGamePlay != null && !AudioGamePlay.isPlaying)
        {
            AudioGamePlay.Play();
        }
    }
}
