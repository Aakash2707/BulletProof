using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText, checkPointText, finalScoreText;
    public GameObject CheckPoint;
    public int score, checkPoint = 0;
    public float Timer = 0;
    public float distance = 0;
    public Transform spawnLocation;
    public float speed;
    public bool cp;
    public SpaceShipController ssc;
    public Image life1, life2, life3;
    public Color deadColor;
    public bool test;
    public GameObject destroy, gameOverScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        Timer += Time.deltaTime;
        distance = Timer * 10;

        if(distance > 200){
            checkPoint++;
            StartCoroutine(checkPointSpawner());
            distance = 0;
            Timer = 0;
        }
        checkPointText.text = (checkPoint*1000).ToString() + "m";
        if(cp){
            move();
        }

        if(ssc.life == 2){
            life3.color = deadColor;
        }
        else if(ssc.life == 1){
            life3.color = deadColor;
            life2.color = deadColor;
        }
        else if( ssc.life == 0){
            life3.color = deadColor;
            life2.color = deadColor;
            life1.color = deadColor;
            if(!test){
                StartCoroutine(Dead());
                test = true;
            }
        }

    }

    public IEnumerator checkPointSpawner(){
        CheckPoint.transform.position = spawnLocation.position;
        cp = true;
        yield return new WaitForSeconds(5f);
        cp = false;
    }

    public IEnumerator Dead(){
    ssc.death.Play();
    Instantiate(destroy,ssc.gameObject.transform.position, ssc.gameObject.transform.rotation);
    Destroy(ssc.gameObject);
    yield return new WaitForSeconds(2.5f);
    Time.timeScale = 0f;
    gameOverScreen.SetActive(true);
    finalScoreText.text = score.ToString();
    }

    void move(){

        Vector2 temp = CheckPoint.transform.position;
        temp.y -= speed * Time.deltaTime;
        CheckPoint.transform.position = temp;
    }
}
