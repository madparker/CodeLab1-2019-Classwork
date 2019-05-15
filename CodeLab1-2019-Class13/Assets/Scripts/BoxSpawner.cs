using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public BoxPool pool;
    public float spawnTime = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime); //call spawn every after spawnTime seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        pool.GetBox(); //get a box from the pool
    }
}
