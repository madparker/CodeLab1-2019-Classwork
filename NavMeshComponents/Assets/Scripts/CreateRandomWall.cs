using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateRandomWall : MonoBehaviour
{
    public NavMeshSurface surface;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if you hit spacebar
        {
            GameObject newWall = Instantiate(Resources.Load<GameObject>("Prefabs/Cube"));  //create a cube
            newWall.transform.position = new Vector3(Random.Range(-7f, 7f), 0.5f, Random.Range(-7f, 7f));//at a random position in the scene
            surface.BuildNavMesh(); //recalculate the NavMeshSurface based on new walls
        }
    }
}
