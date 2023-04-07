using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    void Start()
    {
        Invoke("destroy", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        move();
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