using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed=5f;
    private float turnspeed=25;
    private float HorizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        HorizontalInput=Input.GetAxis("Horizontal");
        forwardInput=Input.GetAxis("Vertical");
        //move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime*speed*forwardInput);   
        transform.Rotate(Vector3.up,Time.deltaTime*turnspeed*HorizontalInput); 
    }
}
