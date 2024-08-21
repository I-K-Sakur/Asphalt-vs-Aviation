using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject AviationCamera;
    public GameObject AShphaltCamera;
    public GameObject AviationAICamera;
    public GameObject AshphaltAICamera;
    public GameObject Camera;
    
    public AudioListener aviationAudioListener;
    public AudioListener ashphaltAudioListener;
    public AudioListener aviationAIAudioListener;
    public AudioListener ashphaltAIAudioListener;

    public bool AviationAICamON;
    public bool AshphaltAICamON;
    public bool AviationCamON;
    public bool AshphaltCamON;
    public AudioSource[] audiosource;

    void Start()
    {
          DisableAllAudioListenersExcept(aviationAIAudioListener,aviationAudioListener);
          
        foreach(AudioSource audioSources in audiosource)
        {
            if(audioSources.isPlaying)
            {
                audioSources.Stop();
            }
        }
        AviationCamON = true;
        AshphaltCamON = false;
        AshphaltAICamON = false;
        AviationAICamON = true;

        Camera.SetActive(true);
        AshphaltAICamera.SetActive(false); // Ensure the other camera is initially inactive
        AShphaltCamera.SetActive(false);

        //DisableAllAudioListenersExcept(aviationAIAudioListener);
    }

    void Update()
    {
        Camera.SetActive(false);
        if ((AviationCamON || AviationAICamON) && Input.GetKeyDown(KeyCode.C))
        {
            SwitchToAshphaltView();
        }
        else if ((AshphaltCamON || AshphaltAICamON) && Input.GetKeyDown(KeyCode.C))
        {
            SwitchToAviationView();
        }
    }

    void SwitchToAshphaltView()
    {
        AshphaltCamON = true;
        AshphaltAICamON = true;
        AviationAICamON = false;
        AviationCamON = false;

        AshphaltAICamera.SetActive(true);
        AviationAICamera.SetActive(false);
        AShphaltCamera.SetActive(true);
        AviationCamera.SetActive(false);

        DisableAllAudioListenersExcept(ashphaltAudioListener,ashphaltAIAudioListener);
       // AshphaltAudioSource();
    }

    void SwitchToAviationView()
    {
        AviationCamON = true;
        AviationAICamON = true;
        AshphaltCamON = false;
        AshphaltAICamON = false;

        AshphaltAICamera.SetActive(false);
        AviationAICamera.SetActive(true);
        AviationCamera.SetActive(true);
        AShphaltCamera.SetActive(false);
        
        DisableAllAudioListenersExcept(aviationAIAudioListener,aviationAudioListener);
        //AviationAudioSource();
        
    }

    void DisableAllAudioListenersExcept(AudioListener activeListener,AudioListener activeListener2)
    {
        aviationAudioListener.enabled = false;
        ashphaltAudioListener.enabled = false;
        aviationAIAudioListener.enabled = false;
        ashphaltAIAudioListener.enabled = false;

        activeListener.enabled = true;
        activeListener2.enabled=true;
    }
    void AviationAudioSource()
     {
        for(int i=3;i<6;i++)
        {
            audiosource[i].Play();
        }
     }
    void AshphaltAudioSource()
     {
        for(int i=0;i<3;i++)
        {
            audiosource[i].Play();
        }
     }
}
