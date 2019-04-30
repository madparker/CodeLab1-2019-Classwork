using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemList : MonoBehaviour
{
    
    public List<GameObject> gems;// declared my List of GameObjects
    
    // Start is called before the first frame update
    void Start()
    {
        gems = new List<GameObject>(); //init the List of GameObjects
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if Space is pressed
        {
            gems.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Cube"))); //create a new Cube and add it to the end of the List
            
            gems[gems.Count - 1].transform.position = new Vector3(gems.Count, -3, 0); //set the position of the last gem to be based on their position
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject middle = gems[gems.Count/2]; //game.Count is the number of slots in the list,
                                                    //dividing by 2 gets us the middle
            gems.Remove(middle); //remove the gameObject regardless of where it is in the list

            Destroy(middle); //destroy the gameObject to remove it from the scene
        }
    }
}
