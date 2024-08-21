using UnityEngine;
using System.Collections.Generic;
// using System.Linq;

public class GameOverManager : MonoBehaviour
{
    public float TotalTime=10f;
    //private MonoBehaviour[] allScripts;
    //[SerializeField] private MonoBehaviour gameOverScript;
     public GameObject gameOver;
     public GameObject AshphaltText;
     public GameObject AviationText;
     public bool TextOnHoise=false;
    void Start()
    {
        behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;

       AshphaltBoxGameOver AshphaltBoxGameOver=FindObjectOfType<AshphaltBoxGameOver>();
        BoxGameOver BoxGameOver=FindObjectOfType<BoxGameOver>();
        //AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
       // behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
       gameOverScript gameOverScript=FindObjectOfType<gameOverScript>();
       if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
   
    }

    public void Update()
    {
      if(AviationWeaponBehaviour.GameScore<=0 && TextOnHoise==false)
      {
          AviationText.SetActive(true);
          TextOnHoise=true;
      }
      if(behaviourofelements.AshphaltScore<=0 && TextOnHoise==false)
      {
        AshphaltText.SetActive(true);
        TextOnHoise=true;
      }
        // Enable the game over script
        if (gameOver != null && AshphaltBoxGameOver.AshphaltGameOverholo==true||
              BoxGameOver.BoxGameOverGameOver==true|| AviationWeaponBehaviour.AviationWeaponBehaviourGameOver==true||
              behaviourofelements.behaviourofelementsGameOver==true  )
        {
        //    StartCoroutine( MyNewCoroutine());
          TotalTime=(TotalTime-Time.deltaTime); 
          if(TotalTime<=0f && (behaviourofelements.AshphaltScore<=0 || AviationWeaponBehaviour.GameScore<=0 ))
          {

            //yield return new WaitForSeconds(10f);
            gameOver.SetActive(true);
          }
        }

        //Debug.Log("Game Over triggered!");
    }
  

}
