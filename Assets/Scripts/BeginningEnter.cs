using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningEnter : MonoBehaviour
{
    public GameObject MainMenuButton;
    public GameObject GameStartUI;
    public GameObject ButtonAndOther;
     public GameObject MainMenu;
    // public GameObject QuitMenu;
    public GameObject GameOverUI;
    public GameObject AviationSlider;
    public GameObject AshphaltSlider;
    public GameObject Help;
    public GameObject About;
    public GameObject[] Back;
    public static bool eiholoshuru;
   public GameObject quit;
 
    public GameObject GamePlayAudio;
    public GameObject GameStartAudio;
    public GameObject AudioCamera;
     public GameObject AshphaltWonText;
      public GameObject AviationWonText;
    // public AudioSource AudioGamePlay;
     // public GameObject Animation;
    // Start is called before the first frame update
    void Start()
    {
      AshphaltWonText.SetActive(false);
      AviationWonText.SetActive(false);
        AudioCamera.SetActive(false);
        // AudioGamePlay.Play();
      GameStartAudio.SetActive(false);
        eiholoshuru=false;
        for(int i=0;i<9;i++)
        {
            Back[i].SetActive(false);
        }
        Help.SetActive(false);
        //quit.SetActive(false);
        About.SetActive(false);
        MainMenuButton.SetActive(false);
        GameStartUI.SetActive(true);
        ButtonAndOther.SetActive(false);
        MainMenu.SetActive(false);
         //QuitMenu.SetActive(false);
        GameOverUI.SetActive(false);
        AviationSlider.SetActive(false);
        AshphaltSlider.SetActive(false);
         behaviourofelements behaviourofelements=FindObjectOfType<behaviourofelements>();
        behaviourofelements.AshphaltScore=5;
        AviationWeaponBehaviour AviationWeaponBehaviour=FindObjectOfType<AviationWeaponBehaviour>();
        AviationWeaponBehaviour.GameScore=5;
      //    sliders[1].SetActive(false);
      //  sliders[2].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(eiholoshuru==false && Input.GetKeyDown(KeyCode.Return))
        {
           GameStartUI.SetActive(false);
           
       
           MainMenuButton.SetActive(true);
           Help.SetActive(true);
           About.SetActive(true);
           quit.SetActive(true);
           //QuitMenu.SetActive(true);
          
           eiholoshuru=true;
        //    text[1].SetActive(false);
        //    text[2].SetActive(false);
           //Animation.SetActive(false);
        }
    }
}
