using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class behaviourofelements : MonoBehaviour
{
    public static bool behaviourofelementsGameOver=false;
    public GameObject Aviation;
    public GameObject Detectarget;
    public Transform target;
    public float movespeed = 60f;
    public float komaspeed = -2f;
    private Rigidbody rb;
    public float detectionradius = 10f;
    public static int AshphaltScore ;
    public GameObject AviationParticleSystemPrefab;

    private GameObject instantiatedParticleSystem;
    public GameObject GameOverUI;
  public AudioSource AviationWeaponHittedSource;
  public AudioClip AvationHittedClip;
public AudioSource AviationDestroyed;
public AudioClip AvationDestroyedClip;
public GameObject AviationDestroyedObject;
public static bool AviationDestryHoise=false;
  //public GameObject AviationAttackSound;
    // Start is called before the first frame update
    void Start()
    {
         //AviationAttackSound.SetActive(false);
        //AshphaltScore=5;
        rb = GetComponent<Rigidbody>();
        Detectarget = GameObject.FindGameObjectWithTag("aviationplan");

        // Ensure that the particle system prefab is assigned
        if (AviationParticleSystemPrefab == null)
        {
            Debug.LogError("AviationParticleSystemPrefab is not assigned.");
        }
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Detectarget != null)
        {
            target.position = Detectarget.transform.position;
            GoingUpper();
            DetectTarget();
            MoveTowardsTarget();
            HittingTarget();
            DestroyingObject();
            GameOver();
        }
        else
        {
            Debug.LogWarning("Target did not hit");
        }
    }

    void GoingUpper()
    {
        Vector3 position = new Vector3(0, Time.deltaTime * movespeed * 5, 0);
        rb.velocity = position;
    }

    void DetectTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, detectionradius))
        {
            if (hit.collider.CompareTag("aviationplan"))
            {
                MoveTowardsTarget();
            }
        }
    }

    void MoveTowardsTarget()
    {
        transform.LookAt(target.position);
    }

    void HittingTarget()
    {
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }

    void DestroyingObject()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield return new WaitForSeconds(6f);
        GameOverUI.SetActive(true);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("aviationplan"))
        {
             AviationWeaponHittedSource.PlayOneShot(AvationHittedClip);
           // AviationAttackSound.SetActive(true);
            AshphaltScore-=1;
            Destroy(gameObject);
            //AviationDestroyed.PlayOneShot(Avationdestroysound);
           
            Debug.Log("AviationLife:" + AshphaltScore);
        }
    }

    void GameOver()
    {
        if (AshphaltScore <= 0)
        {
            GameOverRotateAviation();
            if (AviationParticleSystemPrefab != null)
            {
                AviationDestryHoise=true;
               // AviationDestroyed.PlayOneShot(AvationDestroyedClip);
                //AviationDestroyedObject.SetActive(true);
                instantiatedParticleSystem = Instantiate(AviationParticleSystemPrefab, transform.position, Quaternion.identity);
                instantiatedParticleSystem.SetActive(true);
                behaviourofelementsGameOver=true;
            }
            Debug.Log("Game Over and the winner is Ashphalt");
        }
    }

    void GameOverRotateAviation()
    {
        if (Aviation != null)
        {
            Detectarget.transform.Rotate(Vector3.forward * -40f * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Aviation Object not assigned");
        }
    }

}
