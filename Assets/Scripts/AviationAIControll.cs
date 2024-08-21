using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviationAIControll : MonoBehaviour
{
    private float ForwardSpeed;
    public Rigidbody PlayerRb;
    public GameObject Propeller;
    private float SpeedOFAviation = 30f;
   // private float RotationSpeed = 45f;
    private float UpperLimit = 80f;
    private float LowerLimit = 30f;
    private float[] randomAviationRotation = { 20f, -20f, 45f, -45f, 90f, -90f, 180f, -180f };
    private float goingUpSpeed = 100f;
    public GameObject[] Element_Of_Attack;
    public int RandomElement;
    private float attackCooldown = 2f;
    private float attackTimer = 0f;
    public AudioSource AviationWeaponAttackSource;
    public AudioClip  AviationWeaponAttackClip;
    //public GameObject Box;
    void Start()
    {
        // Initialize position trackers
        ForwardSpeed = SpeedOFAviation;
        attackTimer = attackCooldown;
    }

    void Update()
    {
        // Update the attack timer
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }

        // Move forward continuously
       MoveForward();

        // Check for game over condition
        
    }

    void FixedUpdate()
    {
        if (Propeller != null)
        {
            // Check borders and attack when needed
            CheckingBorderLimit();
            DetectBorder();
            AttackOnAshphalt();
        }
    }

    void MoveForward()
    {
        //float randomRotation = randomAviationRotation[Random.Range(0, randomAviationRotation.Length)];
        transform.Translate(Vector3.forward * Time.deltaTime * SpeedOFAviation);
        //transform.Rotate(Vector3.up,10f );
    }

    void Stop()
    {
        PlayerRb.velocity = Vector3.zero;
        PlayerRb.angularVelocity = Vector3.zero;
    }

    void CheckingBorderLimit()
    {
        if (transform.position.y >= UpperLimit)
        {
            transform.Translate(Vector3.down * Time.deltaTime * goingUpSpeed);
        }
        if (transform.position.y <= LowerLimit)
        {
            transform.Translate(Vector3.up * Time.deltaTime * goingUpSpeed);
        }
    }

    void DetectBorder()
    {
        Vector3 RayCastPosition = Propeller.transform.position;
        Ray rayforward = new Ray(RayCastPosition, transform.forward);
        RaycastHit hitForward;
        Debug.DrawRay(rayforward.origin, transform.TransformDirection(Vector3.forward) * 20f, Color.white);

        if (Physics.Raycast(rayforward, out hitForward, 20f))
        {
            if (hitForward.collider.CompareTag("BackBorder") ||
                hitForward.collider.CompareTag("RightBorder") ||
                hitForward.collider.CompareTag("LeftBorder") ||
                hitForward.collider.CompareTag("FrontBorder"))
            {
                Stop();
                StartCoroutine(MyCoroutine(4f));
                Rotate();
            }
        }
    }

    void Rotate()
    {
        float randomRotation = randomAviationRotation[Random.Range(0, randomAviationRotation.Length)];
        transform.Rotate(Vector3.up, randomRotation);
    }

    void AttackOnAshphalt()
    {
        Vector3 RayCastPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        Ray raydown = new Ray(RayCastPosition, Vector3.down);
        RaycastHit hitdown;
        Debug.DrawRay(raydown.origin, transform.TransformDirection(Vector3.down) * 100f, Color.yellow, 5f);

        if (Physics.Raycast(raydown, out hitdown, 1000f))
        {
            if (hitdown.collider.CompareTag("Ashphalt") && attackTimer <= 0f)
            {
                Debug.Log("Attack Successful");
                Vector3 Position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                AviationWeaponAttackSource.PlayOneShot(AviationWeaponAttackClip);
                Instantiate(Element_Of_Attack[Random.Range(0, Element_Of_Attack.Length)], Position, transform.rotation);
                attackTimer = attackCooldown;
            }
        }
    }

    IEnumerator MyCoroutine(float n)
    {
        yield return new WaitForSeconds(n);
    }

    


}
