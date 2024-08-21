using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAudio : MonoBehaviour
{
    // Start is called before the first frame update
public AudioSource AudioStart;
public AudioListener[] AudioListeners;
    // Update is called once per frame

    void Update()
    {
        AudioStart.Play();
    }
}
