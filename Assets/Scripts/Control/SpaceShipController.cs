using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceShipController : MonoBehaviour
{

    public SwipeManager swipe;
    public float speed;
    public float minX, maxX;
    public float delay, delaySP;
    public GameObject laser;
    public Button Shoot;                
    public Transform laserPoint;
    public bool multiLaserShot, spreadDamage, forceField;
    public GameObject forcefield;
    public Quaternion rotation;
    public Quaternion point1, point2, point3, point4;
    public int life = 3;
    public float powerUpTime;
    public AudioSource death;

    void Awake(){
        death = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        rotation = laserPoint.transform.rotation;
    }


    void Update()
    {
        moveSpaceShip();
        rotation = laserPoint.transform.rotation;
        if(forceField){
            forcefield.SetActive(true);
        }
        else{
            forcefield.SetActive(false);
        }
        
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

    IEnumerator MultiShot(){
        multiLaserShot = true;
        yield return new WaitForSeconds(powerUpTime);
        multiLaserShot = false;
    }
    IEnumerator SpreadShot(){
        spreadDamage = true;
        yield return new WaitForSeconds(powerUpTime);
        spreadDamage = false;
    }
    IEnumerator ForceField(){
        forceField = true;
        yield return new WaitForSeconds(powerUpTime);
        forceField = false;
    }
    public void MultiShot1(){
        StartCoroutine(MultiShot());
    }
    public void SpreadShot1(){
        StartCoroutine(SpreadShot());
    }
    public void ForceField1(){
        StartCoroutine(ForceField());
    }
}
