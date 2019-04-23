using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSphere : MonoBehaviour
{
    Quaternion startRot;
    
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
//        transform.LookAt(Camera.main.transform);

        transform.RotateAround(Vector3.zero, Vector3.forward, 1);
    }
}
