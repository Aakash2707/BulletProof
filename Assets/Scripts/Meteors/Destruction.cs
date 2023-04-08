using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource explode;

    void Awake() {
        explode = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        explode.Play();
        Invoke("destroy",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void destroy(){
        Destroy(gameObject);
    }
}
