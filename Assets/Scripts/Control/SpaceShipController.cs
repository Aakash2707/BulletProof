using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipController : MonoBehaviour
{

    public SwipeManager swipe;
    public float speed;
    public float minX, maxX;
    public float delay, delaySP;
    public GameObject laser;
    public Button Shoot;                
    public Transform laserPoint;
    public bool multiLaserShot, spreadDamage;
    public Quaternion rotation;
    public Quaternion point1, point2, point3, point4;
    void Start()
    {
        rotation = laserPoint.transform.rotation;
    }


    void Update()
    {
        moveSpaceShip();
        rotation = laserPoint.transform.rotation;
        
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

    public void shoot(){
        StartCoroutine(ShootFn());
    }

    public IEnumerator ShootFn() {
        if(multiLaserShot){
            Instantiate(laser, laserPoint.position,laserPoint.transform.rotation);
            yield return new WaitForSeconds(delaySP);
            Instantiate(laser, laserPoint.position,laserPoint.transform.rotation);
            yield return new WaitForSeconds(delaySP);
            Instantiate(laser, laserPoint.position,laserPoint.transform.rotation);
            yield return new WaitForSeconds(delaySP);
            Instantiate(laser, laserPoint.position,laserPoint.transform.rotation);
        }
        else if(spreadDamage){
            Instantiate(laser, laserPoint.position,point1);
            Instantiate(laser, laserPoint.position,point2);
            Instantiate(laser, laserPoint.position,point3);
            Instantiate(laser, laserPoint.position,point4);
        }
        else{
            Instantiate(laser, laserPoint.position,laserPoint.transform.rotation);
        }
        Shoot.interactable = false;
        yield return new WaitForSeconds(delay);
        Shoot.interactable = true;
    }
}
