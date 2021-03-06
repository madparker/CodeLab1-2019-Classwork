﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a thing that looks at stuff (ideally, a camera)
// PURPOSE: this will make the thing look at a thing, forever
public class CameraLookFollow : MonoBehaviour
{
    public Transform lookTarget; // what I should look at; assign in Inspector!

    void Update()
    {
        // bug fix after we worked on RaycastButton.cs: if "lookTarget" does not exist, then don't do anything
        if ( lookTarget == null ) { // "null" means like "empty"
            return; // "return" means skip the rest of this function and stop
        }

        // technique 1: use "LookAt"... very simple, but very basic
        // transform.LookAt( lookTarget );

        // technique 2: use Quaternions to make the thing look at the thing
        Vector3 forward = lookTarget.position - transform.position; // line from A to B = B-A
        // calculate quaternion based on the forward vector desired
        Quaternion targetRotation = Quaternion.LookRotation( forward );
        // change the rotation based on quaternions...

        // FOR A MORE MECHANICAL FEEL, LIKE A SECURITY CAMERA
        // rotate towards the object at a rate of 30 degrees per second
        // transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, 30f * Time.deltaTime);
    
        // FOR A MORE ORGANIC FEEL, eases in and out / dampens / accelerates
        transform.rotation = Quaternion.Slerp( transform.rotation, targetRotation, 5f * Time.deltaTime );
    }
}
