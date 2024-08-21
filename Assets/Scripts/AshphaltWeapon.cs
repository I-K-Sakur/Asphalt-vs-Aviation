using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using QAudioManager; 
using Ami.BroAudio;
public class AshphaltWeapon : MonoBehaviour
{
  // [SerializeField] SoundID _music=default;
    public GameObject Weapon;
    public AudioSource Ashphaltbombnew;
   public AudioClip  Ashphaltbombupper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(transform.position.x,transform.position.y+2,transform.position.z);
        
         if(Input.GetKeyDown(KeyCode.Return))
        {
        
          Ashphaltbombnew.PlayOneShot(Ashphaltbombupper);
        Instantiate(Weapon,position,transform.rotation);
        
        //GoingUpper= Input.GetKeyDown(KeyCode.Space);

       }
      
    }


}
