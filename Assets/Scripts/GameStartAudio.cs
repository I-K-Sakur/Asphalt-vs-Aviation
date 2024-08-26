using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAudio : MonoBehaviour
{
    public AudioSource AudioStart;
    public AudioListener[] AudioListeners;

    void Start()
    {
        // Ensure the AudioSource is enabled before playing
        if (AudioStart != null && AudioStart.enabled && AudioStart.gameObject.activeInHierarchy)
        {
            AudioStart.Play();
        }
        else
        {
            Debug.LogError("AudioSource is either null, disabled, or the GameObject is inactive.");
        }
    }
}
