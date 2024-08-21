using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AshphaltHealth : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        int AviationLife=AviationWeaponBehaviour.GameScore;
        slider.value=AviationLife;
    }
}
