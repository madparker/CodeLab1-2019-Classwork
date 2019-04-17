using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put on your Main Camera
// PURPOSE: demo some camera control techniques, 
// like simple mouse look / following a target
public class CameraDemo : MonoBehaviour
{
    void Update()
    {
        // simple mouse look that is kind of broken, but works

        // 1. get mouse input?
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");
        float verticalMouseSpeed = Input.GetAxis("Mouse Y");
        Debug.Log( horizontalMouseSpeed ); // print horizontal mouse, make sure it works

        // 2. use mouse input to rotate camera
        transform.Rotate(0f, horizontalMouseSpeed, 0f );
        Camera.main.transform.Rotate( -verticalMouseSpeed, 0f, 0f );

        // 3. unroll the camera, we need to set it's Z angle to 0f, always?
        // transform.eulerAngles.z = 0f; // Unity won't let you do it like this
        transform.eulerAngles = new Vector3( transform.eulerAngles.x,
                                             transform.eulerAngles.y,
                                             0f );
        
    }
}
