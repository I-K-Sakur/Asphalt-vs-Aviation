using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAudio : MonoBehaviour
{
    // Start is called before the first frame update
 
public AudioSource AudioGamePlay;
    // Update is called once per frame

    void Update()
    {
        AudioGamePlay.Play();
    }
}
