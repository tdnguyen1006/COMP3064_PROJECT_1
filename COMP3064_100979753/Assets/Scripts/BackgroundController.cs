using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Source Unity - 2D Infinite Scrolling Background the Simplest Way - https://www.youtube.com/watch?v=HrDxnMI7pCc

public class BackgroundController : MonoBehaviour {
    
    // Update is called once per frame
    void Update()
    {
        //Make the background scroll from right to left
        Vector2 offset = new Vector2(Time.time * 0.1f, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
