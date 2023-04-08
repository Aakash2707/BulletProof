using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject infoScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play(){
        SceneManager.LoadScene("GameScene");
    }
    public void exitGame(){
        Application.Quit();
    }
    
    public void InfoScreen(){
        infoScreen.SetActive(true);
    }
}
