using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = new Vector3();
        
        if (Input.GetKey(KeyCode.A)) //move left
        {
            newVelocity.x += -speed;
        }

        if (Input.GetKey(KeyCode.D)) //move right
        {
            newVelocity.x += speed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //shoot
        {
            Shoot();
        }

        rb.velocity = newVelocity;
    }

    void Shoot()
    {
        GameObject newBullet = BulletPool.instance.GetBullet(); //Get a bullet from the pool
        newBullet.transform.position = new Vector3( //set it's position based on player location
            transform.position.x,
            transform.position.y + 2,
            transform.position.z);
        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * 5; //give it a new velocity
        
    }
}
