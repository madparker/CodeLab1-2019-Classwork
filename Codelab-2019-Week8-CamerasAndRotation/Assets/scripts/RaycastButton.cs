using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an object (with a collider) to make it clickable
// FUNCTION: shoot raycast based on mouse cursor to detect any colliders
public class RaycastButton : MonoBehaviour
{
    void Update()
    {
        // STEP 1: generate a "Ray" variable
        Ray myRay = Camera.main.ScreenPointToRay( Input.mousePosition );

        // STEP 2: visualize the raycast in debug Scene view
        Debug.DrawRay( myRay.origin, myRay.direction * 1000f, Color.yellow );

        // STEP 3: initialize a RaycastHit variable
        // "RaycastHit" is a type of variable that has more info about what it hit
        RaycastHit myRayHitInfo = new RaycastHit();

        if ( Input.GetMouseButtonDown( 0 ) ) {
            // STEP 4: actually shoot raycast now!
            if ( Physics.Raycast( myRay, out myRayHitInfo, 1000f ) ) {
                // STEP 5: do something with the raycast!
                // actually, the way we've coded this, we can now click on ANYTHING with a collider
                // Destroy( myRayHitInfo.collider.gameObject );

                // "Translate" means "move position"
                myRayHitInfo.transform.Translate( 0f, 1f, 0f);

                // change color when I click on it
                myRayHitInfo.transform.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0f, 1f);
            }
        }
    }

    // secret faster way to make a raycast button
    // but then you need to put one of these scripts on each gameobject
    void OnMouseDown() {
        // OnMouseDown happens on the object you put the script on
        Debug.Log("you clicked on me! my name is " + name);
        transform.Translate(0f, 1f, 0f);
    }

}
