using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshphaltBoxGameOver : MonoBehaviour
{
  public AudioSource AshphaltexplostionAudioSource;
   public AudioClip  AshphaltexplostionAudioClip;
 public AudioSource AshphaltExplosionParticleSoundSource ;
   public AudioClip  AshphaltExplosionParticleSoundClip;
    public static bool AshphaltGameOverholo=false;
    public GameObject AshphaltParticleSystem;
    public Rigidbody AshphaltRb;
    public GameObject Ashphalt;
    public Vector3 AshphaltPosition;
   // public float AshphaltRotation;
    // Start is called before the first frame update
    void Start()
    {
      
          AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;
        AviationWeaponBehaviour.AshphaltDestroyHoise=false;
        // behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        // behaviourofelements.AshphaltScore=5;
      AshphaltParticleSystem.SetActive(false);
        // Ensure the Rigidbody is assigned
        if (AshphaltRb == null)
        {
            AshphaltRb = GetComponent<Rigidbody>();
        }
    }
 public void Update() {
   AshphaltPosition=Ashphalt.transform.position;
   if(AviationWeaponBehaviour.AshphaltDestroyHoise)
   {
      AshphaltexplostionAudioSource.PlayOneShot(AshphaltexplostionAudioClip);
       AshphaltExplosionParticleSoundSource.PlayOneShot(AshphaltExplosionParticleSoundClip);
   }
   //AshphaltRotation=90f;
 }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BackBorder") || other.CompareTag("RightBorder") ||
            other.CompareTag("LeftBorder") || other.CompareTag("FrontBorder"))
        {
            //behaviourofelements.AshphaltScore=0;
            AviationWeaponBehaviour.GameScore=0;
            GameOver();
        }
    }

    void GameOver()
    {
        AshphaltexplostionAudioSource.PlayOneShot(AshphaltexplostionAudioClip);
        // Set mass directly to a specific value
        AshphaltRb.mass = 1000f;

        InitiateParticleSystem();
        AshphaltGameOverholo=true;
        
        Debug.Log("GameOver For Ashphalt");
    }

    void InitiateParticleSystem()
    {
        if (AshphaltParticleSystem != null)
        {
          AshphaltexplostionAudioSource.PlayOneShot(AshphaltexplostionAudioClip);
            AshphaltExplosionParticleSoundSource.PlayOneShot(AshphaltExplosionParticleSoundClip);
          AshphaltParticleSystem.SetActive(true);
            // Instantiate the particle system at the current position and rotation
            //Instantiate(AshphaltParticleSystem, AshphaltPosition,transform.rotation);
        }
        else
        {
            Debug.LogWarning("AshphaltParticleSystem is not assigned.");
        }
    }
}
