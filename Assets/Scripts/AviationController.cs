
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AviationController : MonoBehaviour
{
    public GameObject[] Element_Of_Attack;
    public float SpeedOFAviation=400f;
    public float RoationSpeed=180f;
    public float AviationForward;
    public float AviationHorizontal;
   //public float GoingUpper;
    public float goingupperspeed=100f;
    private int range;
    public AudioSource AviationWeaponAttackSource;
    public AudioClip  AviationWeaponAttackClip;
    //public float  position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         range=Random.Range(0,Element_Of_Attack.Length);
             Vector3 position = new Vector3(transform.position.x,transform.position.y-2,transform.position.z);
        if(Input.GetKeyDown(KeyCode.Return))
        {
         AviationWeaponAttackSource.PlayOneShot(AviationWeaponAttackClip);
        Instantiate(Element_Of_Attack[range],position,transform.rotation);
        }
        //GoingUpper= Input.GetKeyDown(KeyCode.Space);
       AviationHorizontal= Input.GetAxis("Horizontal");
       AviationForward= Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward*Time.deltaTime*SpeedOFAviation*AviationForward);
       transform.Rotate(Vector3.up*Time.deltaTime*RoationSpeed*AviationHorizontal);
       if(Input.GetKey(KeyCode.Space))
       {
          transform.Translate(Vector3.up*goingupperspeed*Time.deltaTime);
       }
        if(Input.GetKey(KeyCode.U))
       {
          transform.Translate(Vector3.down*goingupperspeed*Time.deltaTime);
       }
       if(Input.GetKey(KeyCode.R))
       {
         transform.Rotate(new Vector3(0,0,0)*Time.deltaTime*RoationSpeed*AviationHorizontal);
       }
      
    
    }

  
}
