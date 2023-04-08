using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
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
