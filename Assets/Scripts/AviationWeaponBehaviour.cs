using UnityEngine;
using System.Collections;
using System.ComponentModel;
//using System.Numerics;
public class AviationWeaponBehaviour : MonoBehaviour
{
  public static bool AviationWeaponBehaviourGameOver=false;
  public GameObject Ashphalt;
  public GameObject AshphaltParticleSystem;
   private GameObject instantiatedParticleSystem;
  //public Rigidbody AviationRb;
   // public float Rotation=90f;
    public GameObject Detectarget;
    public Transform target;
    public float movespeed=-50f;
    public float komaspeed=-2f;
    private Rigidbody rb;
    public float detectionradius=10f;
   public static int GameScore;
   public GameObject GameOverUI;
     public AudioSource AshphaltWeaponHittedSource;
  public AudioClip AshphaltHittedClip;
public AudioSource AshphaltDestroyed;
public AudioClip AshphaltDestroyedClip;
public GameObject AviationDestroyedObject;
public static bool AshphaltDestroyHoise=false;
    // Start is called before the first frame update
void Start()
{
    rb = GetComponent<Rigidbody>();
    Detectarget = GameObject.FindGameObjectWithTag("Ashphalt");
    if (Detectarget != null)
    {
        target = Detectarget.transform; // Assigning the transform of the detected target
    }
}

    // Update is called once per frame
  void FixedUpdate() {
    target.position=Detectarget.transform.position;
    if(target!=null)
    {
      GoingDown();
      DetectTarget();
      MoveTowardsTarget();
      HittingTarget();
      DestroyingObject();
      GameOver();
    }
    else{
        Debug.LogWarning("Target did not hit");
    }
}
void GoingDown()
{ 
  Vector3 position = new Vector3(0, Time.deltaTime * movespeed* 5, 0);
        rb.velocity = position;
//     float angle=Vector3.Dot(target.forward,direction);
//     Vector3 rotationamount=Vector3.Cross(target.forward,direction);
//    rb.angularVelocity=rotationamount*rotationSpeed;
// Vector3 position=new Vector3(0,Time.deltaTime*movespeed*5,0);
//     rb.velocity=position;
    // Vector3 position=new Vector3(transform.position.x,transform.position.y*movespeed*Time.deltaTime,transform.position.z);

}
void DetectTarget()
{
    RaycastHit hit;
    Vector3 direction = Vector3.down; // Cast ray directly downward

    Debug.DrawRay(transform.position, target.position-transform.position, Color.red); // Visualize the ray

    if (Physics.Raycast(transform.position, target.position-transform.position, out hit, 1000))
    {
        if (hit.collider.CompareTag("Ashphalt"))
        {
            Debug.Log("Detected Ashphalt below");
            MoveTowardsTarget();
        }
    }
}

  

// void MoveTowardsTarget()
// {
//   transform.LookAt(target.position);
  
// }
void MoveTowardsTarget()
{
    if (target != null)
    {
        transform.LookAt(target.position); // Rotate towards the target
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime); // Move towards the target
    }
}

void HittingTarget()
{
    // Assuming the object should move downwards when hitting
    transform.Translate(Vector3.down * movespeed * Time.deltaTime);
}

// void HittingTarget()
// {
//     transform.Translate(Vector3.down*movespeed*Time.deltaTime);
// }
// private void OnCollisionEnter(Collision other) {
//   if(other.gameObject.tag=="aviationplan")
//   {
//     Destroy(gameObject);
//   }
//  }
void DestroyingObject()
{
   StartCoroutine(MyCoroutine());
}
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GameOver();
        //  yield return new WaitForSeconds(4f);
        // Destroy(gameObject);
        yield return new WaitForSeconds(6f);
        GameOverUI.SetActive(true);

    }
    public void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Ashphalt"))
    {
        AshphaltWeaponHittedSource.PlayOneShot(AshphaltHittedClip);
        GameScore -= 1;
        Destroy(gameObject); // Destroy the object upon collision
        Debug.Log("Aviation Life: " + GameScore);
    }
}

  //  public void OnTriggerEnter(Collider other) {
  //   if(other.CompareTag("Ashphalt"))
  //   {
  //     GameScore-=1;
  //       Destroy(gameObject);
  //       Debug.Log("Aviation Life: "+GameScore);
  //   }
    
  // }
    void GameOver()
    {
        if (GameScore <= 0)
        {
          GameOverRotateAshphalt();
                if (AshphaltParticleSystem != null)
            {
                AshphaltDestroyHoise=true;
                instantiatedParticleSystem = Instantiate(AshphaltParticleSystem, target.position, Quaternion.identity);
                instantiatedParticleSystem.SetActive(true);
                AviationWeaponBehaviourGameOver=true;
            }
          
          // InitiateParticleSystem();
          //Vector3 Rotation=new Vector3(90f,0f,0f);
           //Ashphalt.transform.Rotate(Vector3.down*-90f*Time.deltaTime);
            Debug.Log("Game Over and the winner is aviation");
            // Add logic to handle game over, such as stopping the game or showing a game over screen
        AviationWeaponBehaviourGameOver=true;
        }
    }  
    void GameOverRotateAshphalt()
    {
        if (Ashphalt != null)
        {
            Detectarget.transform.Rotate(Vector3.forward*-40f*Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Ashphalt object not assigned.");
        }
    }
    void  InitiateParticleSystem()
    {
       Instantiate(AshphaltParticleSystem);
    }
}
