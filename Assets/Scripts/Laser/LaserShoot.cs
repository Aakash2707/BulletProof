using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public AudioSource laserSound;

    void Awake() {
        laserSound = gameObject.GetComponent<AudioSource>();
        bc.enabled = false;
        Invoke("EnableCollider", 0.1f);
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
        rb.AddForce(transform.up * 3000 * Time.deltaTime);
        
    }

    void destroy(){
        Destroy(gameObject);
    }
    void EnableCollider(){
        bc.enabled = true; 
    }

}
