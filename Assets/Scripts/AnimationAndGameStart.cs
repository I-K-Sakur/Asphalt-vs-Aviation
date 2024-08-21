using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndGameStart : MonoBehaviour
{
    public GameObject[]  Button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            for(int i=0;i<3;i++)
            {
                Button[i].SetActive(true);
            }
        }
    }
}
