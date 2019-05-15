using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class Zork : MonoBehaviour //Gamemanger for a simple Zork type game
{
    JSONArray jsonArray; //a data structure that holds data from a json file

    int locationIndex = 1; //var for keep 

    //consts for directions, used to make sure we use the same name we have in the file
    const string JSON_EAST = "e";
    const string JSON_WEST = "w";
    const string JSON_SOUTH = "s";
    const string JSON_NORTH = "n";
    const string JSON_TEXT = "storyText";

    //GameObjects for UI in scene
    public Text text;
    public GameObject nButton;
    public GameObject sButton;
    public GameObject eButton;
    public GameObject wButton;

    ZorkNode currentNode; //current zork location
    
    // Start is called before the first frame update
    void Start()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/ZorkNav.json"); //get all the text out of json file
        
        jsonArray = JSON.Parse(jsonString) as JSONArray; //parse the json text and put it into jsonArray

        SetCurrentNode(locationIndex); //get the current node based on the locationIndex
        
        UpdateUI(currentNode); //Update the UI to reflect the current node
    }

    void SetCurrentNode(int locationNum) //get the current node based on locationNum
    {
        print(locationNum);
        
        locationIndex = locationNum - 1; //remove one from the location to match position in the jsonArray (ie, location 1 is 0 in the array) 
        
        currentNode = new ZorkNode(); //make a new ZorkNode
        
        currentNode.locationNum = locationIndex; //set the location num
        currentNode.eLocation = jsonArray[locationIndex][JSON_EAST].AsInt; //set up all 4 directions
        currentNode.wLocation = jsonArray[locationIndex][JSON_WEST].AsInt;
        currentNode.sLocation = jsonArray[locationIndex][JSON_SOUTH].AsInt;
        currentNode.nLocation = jsonArray[locationIndex][JSON_NORTH].AsInt;
        currentNode.storyText = jsonArray[locationIndex][JSON_TEXT]; //set the text for this location
    }

    void UpdateUI(ZorkNode currentNode) //update the UI based on currentNode
    {
        text.text = currentNode.storyText; //set the text to the storyText in currentNode

        //if currentNode for a location is 0, that means there is no json location for that direction, so turn off the button
        if (currentNode.eLocation == 0)
        {
            eButton.SetActive(false);
        }
        else //if there is a number, turn it back on
        {
            eButton.SetActive(true);
        }
        
        
        if (currentNode.wLocation == 0)
        {
            wButton.SetActive(false);
        }
        else
        {
            wButton.SetActive(true);
        }
        
        
        if (currentNode.nLocation == 0)
        {
            nButton.SetActive(false);
        }
        else
        {
            nButton.SetActive(true);
        }
        
        
        if (currentNode.sLocation == 0)
        {
            sButton.SetActive(false);
        }
        else
        {
            sButton.SetActive(true);
        }
    }

    public void ChooseDir(string c) //this function is called when a button is pressed
    {
        
        //depending on which button is pressed, choose the corresponding node for the direction from the current location
        if (c[0] == 'n')
        {
            SetCurrentNode(currentNode.nLocation);
        } else if (c[0] == 's')
        {
            SetCurrentNode(currentNode.sLocation);
        } else if (c[0] == 'e')
        {
            SetCurrentNode(currentNode.eLocation);
        } else if (c[0] == 'w')
        {
            SetCurrentNode(currentNode.wLocation);
        }

        UpdateUI(currentNode);
    }
}
