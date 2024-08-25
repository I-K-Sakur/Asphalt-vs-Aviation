using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QAudioManager; 
public class AshphaltAIController : MonoBehaviour
{
    public float speed=5f;
    public float turnspeed=25f;
    public Transform target;
    public Transform enemyAviation;
    public GameObject detectMor;
    public float detectionradius=0.5f;
    private float[] randomPower={180f,-180f,20f,-20f,45f,-45f,90f,-90f};
    private int range;
      public GameObject Weapon;
      private float time=0f;
      public AudioSource AshphaltAISound;
      public AudioClip  AshphaltAIAudioSound;
    // Start is called before the first frame update
    void Start()
    {
        
        detectMor=GameObject.FindGameObjectWithTag("DetectMor");
      
      
    }

    // Update is called once per frame
    void Update()
    {
        if(time>0f)
        {
            time-=Time.deltaTime;
        }
        
         range=Random.Range(0,randomPower.Length);
        // target.position=detectMor.transform.position;
        if(target!=null)
        {
          MoveForward();
          DetectTurn();
          // RotationOfAshphalt();
          // DetectAviation();
          // FireWeapon();
        }
        if(enemyAviation!=null)
        {
            
            CheckForEnemy();

        }
    }


    void MoveForward()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }

    void DetectTurn()
    {
        Vector3 CarPosition= transform.position;
        Ray ray =new Ray(CarPosition,transform.forward*100f);
        Debug.DrawRay(ray.origin, transform.TransformDirection(Vector3.forward)*100,  Color.white, 1f);
       RaycastHit hit;
       if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward)*100,out hit,detectionradius))
        // if(Physics.Raycast(ray,out hit))
       {
        if(hit.collider.CompareTag("DetectMor"))
        {
           // Debug.Log("Hit korse");
            RotationOfAshphalt();
        }   
       }
    }

    void RotationOfAshphalt()
    {
        
        transform.Rotate(Vector3.up,randomPower[range]);
    }

    void CheckForEnemy()
    {
      Vector3 CarPosition= transform.position;
      Ray rayup=new Ray(CarPosition,transform.up*10f);
      Debug.DrawRay(rayup.origin,transform.TransformDirection(Vector3.up)*50,Color.red,1f);
      RaycastHit hitup;
      if(Physics.Raycast(rayup,out hitup))
       {
       if(hitup.collider.CompareTag("aviationplan") && time<=0f)
        {
            
            Debug.Log("Plan paisi");
             Vector3 position = new Vector3(transform.position.x,transform.position.y+2,transform.position.z);
             AshphaltAISound.PlayOneShot(AshphaltAIAudioSound);
             Instantiate(Weapon,position,transform.rotation);
             time=2f;
        }
      }
    }

    IEnumerator MyCoroutine(float n)
    {
        yield return new WaitForSeconds(n);
    }
}
