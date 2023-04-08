using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsMove : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public bool multiShot, spreadShot, forceField;
    public float powerUpTime;
    public SpaceShipController ssc;
    
    void Awake(){
        ssc = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceShipController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ScoreDetector"){
            destroy();
        }
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Laser"){
            if(multiShot){
                ssc.MultiShot1();
            }
            if(spreadShot){
                ssc.SpreadShot1();
            }
            if(forceField){
                ssc.ForceField1();
            }
            destroy();
        }
    }

    void move(){

        Vector2 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void destroy(){
        Destroy(gameObject);
    }

}
