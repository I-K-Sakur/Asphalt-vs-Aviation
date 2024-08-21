using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AviationHealth : MonoBehaviour
{
    public Slider AshphaltSlider;
    // Start is called before the first frame update
    void Start()
    {
       
        behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
    }

    // Update is called once per frame
    void Update()
    {
        int AshphaltLife =behaviourofelements.AshphaltScore;
        AshphaltSlider.value=AshphaltLife;
       
    }
}
