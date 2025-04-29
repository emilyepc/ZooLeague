using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolla: MonoBehaviour
{
    public float scrollSpeedX;
    public float scrollSpeedY;
    float offsetX;
    float offsetY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offsetX = Time.time * scrollSpeedX;
        offsetY = Time.time * scrollSpeedY;
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
