using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    void Start()
    {
        Invoke("destroy", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot(){
        // Vector2 temp = transform.localPosition;
        // temp.y += speed * Time.deltaTime;
        // transform.position = temp;
        rb.AddForce(transform.up * 5);
        
    }

    void destroy(){
        Destroy(gameObject);
    }

}
