using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1;
    
    GameObject player;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        
        Debug.Log("Found the gameObject: " + player.name);
    }

    // Update is called once per frame
    void Update()
    {   
        //direction to go = the position of player    - position of enemy
        Vector3 direction = player.transform.position - transform.position;

        //direction = direction.normalized;
        direction.Normalize();

        //rb.velocity = direction * speed;

        print("direction: " + direction);
        
        Quaternion newQuatDir = Quaternion.LookRotation(direction);

//        transform.rotation = Quaternion.LookRotation(direction);

        float dotProduct = Vector3.Dot(direction, transform.forward);
        
        print("Dot: " + dotProduct);
        
        Debug.DrawRay(transform.position, transform.forward * 5, Color.cyan);
        Debug.DrawRay(transform.position, direction * 5, Color.green);

        if (dotProduct > 0.5f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newQuatDir, Time.deltaTime);

            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
