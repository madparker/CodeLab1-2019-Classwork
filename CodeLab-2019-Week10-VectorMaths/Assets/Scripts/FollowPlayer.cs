using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1; //make a public speed variable
    
    GameObject player; //declare a var for the player
    Rigidbody rb; //declare a var for the rigidbody
    
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        player = GameObject.Find("Player"); //find the player object
        rb = GetComponent<Rigidbody>(); //get this gameObjects rigidbody component
        
        Debug.Log("Found the gameObject: " + player.name); //print the name of the object found for player
    }

    // Update is called once per frame
    void Update()
    {   
        //direction to go = the position of player  - position of enemy
        Vector3 direction = player.transform.position - transform.position;

        //direction = direction.normalized;
        direction.Normalize(); //normalize the direction, ie make it have a magnitude (length) of 1

        //rb.velocity = direction * speed;

        print("direction: " + direction); //print out the normalized direction
        
        Quaternion newQuatDir = Quaternion.LookRotation(direction); //get the rotation to look at the player

//        transform.rotation = Quaternion.LookRotation(direction);

        //the dotProduce of 2 vectors is 1 if they are the same, -1 if they are opposite, 0 if they are perpendicular
        float dotProduct = Vector3.Dot(direction, transform.forward); //get the dot product of the way the enemy is looking and the direction of the player
        
        print("Dot: " + dotProduct); //print out the dot product
        
        Debug.DrawRay(transform.position, transform.forward * 5, Color.cyan); //use DrawRay to indicate the direction the enemy is facing
        Debug.DrawRay(transform.position, direction * 5, Color.green); //use DrawRay to show the direction to the player

        //Can the enemy see the player?
        if (dotProduct > 0.5f) //if the dot product is large enough (meaning the 2 vectors are close to the same direction)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newQuatDir, Time.deltaTime); //rotate the enemy toward the player

            rb.velocity = transform.forward * speed; //move the enemy forward
        }
        else //if the enemy can't see the player
        {
            rb.velocity = Vector3.zero; //the enemy doesn't move
        }
    }
}
