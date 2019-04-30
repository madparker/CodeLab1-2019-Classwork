using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductDemo : MonoBehaviour
{
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay takes 3 arguments, a point to start the ray, a direction to draw from that point, and a color to draw the ray
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red); //draw a ray from the gameObjects position, in the direction it is facing, make it red
        Debug.DrawRay(transform.position, transform.right * 10, Color.yellow); //draw a ray from the gameObjects position, in coming out it's right face, make it yellow
        
        Debug.DrawLine(ball.transform.position, transform.position, Color.green); //draw a line from the ball position to the gameObject position, make it green

        Vector3 direction = transform.position - ball.transform.position; //get the direction from the plane to the ball

        //the cross product gives you a vector that is perpendicular to 2 vectors
        Vector3 normal = Vector3.Cross(transform.right, transform.forward); //get the normal of the plane with the cross product
   
        Vector3 reflection = Vector3.Reflect(direction, normal);//Vector3.Reflect takes a direction and a normal, gives you the reflection of the angle based on that normal
        
        Debug.DrawRay(transform.position, reflection, Color.magenta); //draw the reflection of the direction in the sceneview
    }
}
