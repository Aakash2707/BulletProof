using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    void Awake() {
        bc.enabled = false;
        Invoke("EnableCollider", 0.2f);
    }
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
        rb.AddForce(transform.up * 3);
        
    }

    void destroy(){
        Destroy(gameObject);
    }
    void EnableCollider(){
        bc.enabled = true; 
    }

}
