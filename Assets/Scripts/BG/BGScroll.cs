using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer mR;
    private float yScroll;

    void Awake() {
        mR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();
    }

    void Scroll(){
        yScroll = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(0f, yScroll);
        mR.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
