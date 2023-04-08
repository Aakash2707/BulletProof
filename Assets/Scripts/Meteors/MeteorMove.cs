using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorMove : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public MeteorSpawner ms;
    public ScoreScript ss;
    public SpaceShipController ssc;
    public int destroyNo = 2; 
    public bool largeMeteor;
    public GameObject l1, l2, l3;
    public GameObject destroy1, destroy2;
    

    void Awake(){
        ms = GameObject.FindGameObjectWithTag("MeteorManger").GetComponent<MeteorSpawner>();
        speed = ms.meteorSpeed;
        ss = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        ssc = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(largeMeteor){
            if(destroyNo == 2){
                l1.SetActive(true);
            }
            else if(destroyNo == 1){
                l1.SetActive(false);
                l2.SetActive(true);
            }
            else if(destroyNo == 0){
                l2.SetActive(false);
                l3.SetActive(true);
            }
        }
        

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ScoreDetector"){
            ss.score += 5;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player"){
            ssc.life--;
            destroy();
        }
        if(other.gameObject.tag == "Laser"){
            if(largeMeteor){
                if(destroyNo == 0){
                    ss.score += 20;
                    destroy();
                    Destroy(other.gameObject);
                }
                else{
                    destroyNo--;
                    Destroy(other.gameObject);
                }
            }
            else{
                ss.score += 10;
                destroy();
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag == "ForceField"){
            destroy();
        }
    }

    void move(){

        Vector2 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void destroy(){
        if(largeMeteor)
            Instantiate(destroy2,transform.position, transform.rotation);
        else
            Instantiate(destroy1,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
