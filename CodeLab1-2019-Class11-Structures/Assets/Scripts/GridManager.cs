using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    Stack<GameObject> stack; //LIFO (last in, first out)
    Queue<GameObject> queue; //FIFO (first in, first out)

    Dictionary<string, string> words; //key->value pairs
    Dictionary<string, Student> studentDirectory;
    
    Dictionary<int, GameObject[][]> levels; //2D Array

    public GameObject[][] grid; //declared an array of GameObjects
    
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[5][]; //init array with 5 columns

//        grid[0] = Instantiate(Resources.Load<GameObject>("Prefabs/Cube"));

        //for loops have 3 parts:
        // part 1: var to track: x = 0
        // part 2: when to exit the loop: x < grid.Length
        // part 3: how to change every time we loop: x++
        for (int x = 0; x < grid.Length; x++) //for loop to go through all the columns 
        {
            grid[x] = new GameObject[6]; //init this column to have 6 rows

            for (int y = 0; y < grid[x].Length; y++) //for loop to go through all the rows
            {

                grid[x][y] = Instantiate(Resources.Load<GameObject>("Prefabs/Cube")); //put a cube in the slot at this column, row

                grid[x][y].transform.position = new Vector3(x, y, 0); //use the column, row to position the cube
            }
        }

        words = new Dictionary<string, string>(); //Init a dictionary called Words
        
        words.Add("Potato", "Versatile delicious root vegetable"); //put a key->value pair into the dictionary
        words.Add("Chartreuse", "Green-ish"); //put a key->value pair into the dictionary
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //when the mouse is clicked
        {   //This is how you'd loop through gameObject in a theortical match3 type game
            for (int x = 0; x < grid.Length - 2; x++) //loop through all the columns
            {
                for (int y = 0; y < grid[x].Length; y++) //loop through all the rows
                {
                    GemType gt1 = grid[x + 0][y].GetComponent<GemType>(); //get the type GemType of the gameObject in this slot
                    GemType gt2 = grid[x + 1][y].GetComponent<GemType>(); //get the type GemType of the gameObject in the slot to the right
                    GemType gt3 = grid[x + 2][y].GetComponent<GemType>(); //get the type GemType of the gameObject in the slot 2 to the right

                    if (gt1.type == gt2.type && gt1.type == gt3.type) //if all the types match
                    {
                        Destroy(grid[x][y]); //Destroy the first gameObject
                    }
                }
            }
        }
    }
}
