using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGameOver : MonoBehaviour
{
  public static bool BoxGameOverGameOver=false;
  public Rigidbody AviationRb;
  public GameObject AviationParticleSystem;
      public AudioSource AviationparticleSource;
    public AudioClip  AviationparticleClip;
        public AudioSource AviationDestroyedSource;
    public AudioClip  AviationDestroyedClip;
    // Start is called before the first frame update
    void Start()
    {
        AviationParticleSystem.SetActive(false);
        // AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        // AviationWeaponBehaviour.GameScore=5;
         behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
        behaviourofelements.AviationDestryHoise=false;
    }

    // Update is called once per frame
   
 private void Update() {
   if(behaviourofelements.AviationDestryHoise)
   {
      AviationparticleSource.PlayOneShot(AviationparticleClip);
      AviationDestroyedSource.PlayOneShot(AviationDestroyedClip);
   }
 }
    private void OnTriggerEnter(Collider other) {
      if(other.CompareTag("BackBorder") ||other.CompareTag("RightBorder")||
      other.CompareTag("LeftBorder")||other.CompareTag("FrontBorder"))
      {
        //AviationWeaponBehaviour.GameScore=0;
       behaviourofelements.AshphaltScore=0;
      
         GameOver();
      }

    }
    void GameOver()
    {
     AviationparticleSource.PlayOneShot(AviationparticleClip);
      AviationDestroyedSource.PlayOneShot(AviationDestroyedClip);
      AviationParticleSystem.SetActive(true);
      BoxGameOverGameOver=true;
      //AviationRb.mass=10f*Time.deltaTime;
      Debug.Log("GameOver For Aviation");
    }
}
