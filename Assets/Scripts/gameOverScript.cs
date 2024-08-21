using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverScript : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Ashphalt;
    public GameObject Aviation;
     public GameObject UI;
     public GameObject AudioCam;
        // Start is called before the first frame update
    void Start()
    {
        AudioCam.SetActive(false);
        behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;

       AshphaltBoxGameOver AshphaltBoxGameOver=FindObjectOfType<AshphaltBoxGameOver>();
        BoxGameOver BoxGameOver=FindObjectOfType<BoxGameOver>();
        //AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
       // behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
       gameOverScript gameOverScript=FindObjectOfType<gameOverScript>();
       UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (behaviourofelements.AshphaltScore<=0 || AviationWeaponBehaviour.GameScore<=0 )
        {
        Ashphalt.SetActive(false);
        Aviation.SetActive(false);
        UI.SetActive(true);
        Camera.SetActive(true);
        Debug.Log("The game is over");
        }
        
    }
}
