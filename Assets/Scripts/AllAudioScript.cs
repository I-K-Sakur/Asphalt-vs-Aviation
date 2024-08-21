using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QAudioManager; 
public class AllAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AshphaltAIController AshphaltAIController=FindObjectOfType<AshphaltAIController>();
        AshphaltBoxGameOver AshphaltBoxGameOver=FindObjectOfType<AshphaltBoxGameOver>();
        AshphaltWeapon AshphaltWeapon=FindObjectOfType<AshphaltWeapon>();
        AviationAIControll AviationAIControll=FindObjectOfType<AviationAIControll>();
        BoxGameOver BoxGameOver=FindObjectOfType<BoxGameOver>();
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
