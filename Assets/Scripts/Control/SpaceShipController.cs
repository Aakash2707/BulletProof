using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{

    public SwipeManager swipe;
    public float speed;
    public float minX, maxX;
    public GameObject laser;
    public Transform laserPoint;
    void Start()
    {
        
    }


    void Update()
    {
        moveSpaceShip();
        
    }

    void moveSpaceShip() {
        if(swipe.rightMove == true){
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if(temp.x > maxX)
                temp.x = maxX;

            transform.position = temp;
        }
        else if(swipe.leftMove == true){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if(temp.x < minX)
                temp.x = minX;

            transform.position = temp;  
        }
    }

    public void shoot() {
        Instantiate(laser, laserPoint.position, laserPoint.transform.rotation);
    }
}
