using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TruningOnReload : MonoBehaviour
{
    public GameObject Reload;
    // Start is called before the first frame update
    void Start()
    {
        Reload.SetActive(false);
         behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.Return) &&(behaviourofelements.AshphaltScore<=0 || AviationWeaponBehaviour.GameScore<=0 ))
        {
            Reload.SetActive(true);
        }
          
    }
}
