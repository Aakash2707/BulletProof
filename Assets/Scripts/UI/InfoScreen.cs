using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    public GameObject infoScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back(){
        infoScreen.SetActive(false);
    }
}
