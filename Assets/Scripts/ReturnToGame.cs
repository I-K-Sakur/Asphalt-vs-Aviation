using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToGame : MonoBehaviour
{
    //public string TheScene;
    public GameObject GameStartUI;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            //SceneManager.LoadScene(TheScene);
            // GameStartUI.SetActive(true);
            GameOverUI.SetActive(false);
            SceneManager.LoadScene(0);
        
    }
}
