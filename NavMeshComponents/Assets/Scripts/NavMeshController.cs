using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Vector3 destination = new Vector3(1, 0, 2);
    Vector3 oldDest; //hold the destination before it changed
    
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);

        oldDest = destination; //set oldDest to the current destination
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != oldDest) //if destination is no longer = to oldDest
        {
            agent.SetDestination(destination); //give the agent a new destination
            oldDest = destination; //update oldDest to be the current destination
        }

        if (Input.GetMouseButtonDown(0)) //Was the mouse clicked?
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
         
            RaycastHit raycastHit = new RaycastHit();

            if (Physics.Raycast(ray, out raycastHit)) //Raycast returns true if it hits something, and populates raycasthit with info about that hit
            {
                destination = raycastHit.point; //set the destination to the location that was clicked on
            }
        }
    }
}
