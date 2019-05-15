using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float offY = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > offY) //if the bullet goes above the top of the screen
        {
            BulletPool.instance.AddBullet(gameObject); //add the bullet to the bullet pool
        }
    }

    void OnCollisionEnter(Collision other)
    {
        BulletPool.instance.AddBullet(gameObject); //if the bullet hits something, add it to the bullet pool
    }
}
