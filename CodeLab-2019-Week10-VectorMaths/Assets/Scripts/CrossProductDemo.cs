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
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        Debug.DrawRay(transform.position, transform.right * 10, Color.yellow);
        
        Debug.DrawLine(ball.transform.position, transform.position, Color.green);

        Vector3 direction = transform.position - ball.transform.position;

        Vector3 normal = Vector3.Cross(transform.right, transform.forward);

        Vector3 reflection = Vector3.Reflect(direction, normal);
        
        Debug.DrawRay(transform.position, reflection, Color.magenta);
    }
}
