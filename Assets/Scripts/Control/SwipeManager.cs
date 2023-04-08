using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 fingerUp, fingerDown;

    public float swipeThreshold;

    public bool rightMove = false;
    public bool leftMove = false;
    public AudioSource swipe;
    void Awake()
    {
        swipe = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches){
            if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
                {
                    
                    fingerDown = touch.position;
                    checkSwipe();
                    
                }

            if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    leftMove = false;
                    rightMove = false;
                }

        }
    }
    void checkSwipe(){

        if (horizontalValMove() > swipeThreshold)
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                //swipe.Play();
                rightMove = true;
                leftMove = false;
               
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                //swipe.Play();
                leftMove = true;
                rightMove = false;
               
            }
            else{
                rightMove = false;
                leftMove = false;
            }
            fingerUp = fingerDown;
        }
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }
}
