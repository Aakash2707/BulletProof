using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    public void exit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
