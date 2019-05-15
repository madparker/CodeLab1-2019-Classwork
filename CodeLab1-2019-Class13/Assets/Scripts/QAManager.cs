using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class QAManager : MonoBehaviour
{

    public Text questionText;
    public Text option1Text;
    public Text option2Text;
	
    QANode currentNode;

    int jsonIndex = 0;

    const string JSON_PAGE_NUM = "pageNumber";
    const string JSON_QUESTION = "questionText";
    const string JSON_OPT1_TEXT = "option1Text";
    const string JSON_OPT2_TEXT = "option2Text";
    const string JSON_OPT1_PAGE = "option1Page";
    const string JSON_OPT2_PAGE = "option2Page";

    string fileLocation;
    JSONArray jsonArray;
    
    // Use this for initialization
    void Start () {
        fileLocation = Application.dataPath + "/QABook.json"; //get the location of the json

        ReadFromJson(fileLocation); //Read in the Json
		
        UpdateUI(currentNode); //Update the UI
    }

    public void ChooseOption(int optionNum) //chose an option
    {
        jsonIndex = optionNum; //set the jsonIndex based on the user choice
        
        ReadFromJson(fileLocation);  //Read in the Json
        UpdateUI(currentNode); //Update the UI
    }

    void ReadFromJson(string fileLocation) //read in all the Json
    {
        if (jsonArray == null) //if we haven't loaded the json into jsonArray already
        {
            string input = File.ReadAllText(fileLocation); //get the json text out of the file

            print(input);

            jsonArray = JSON.Parse(input) as JSONArray; //parse the json from the text and put it into jsonArray
        }

        QANode qaNode = new QANode(); //make a new QANode

        qaNode.pageNumber = jsonArray[jsonIndex][JSON_PAGE_NUM].AsInt;//get the pageNumber from by 
        qaNode.questionText = jsonArray[jsonIndex][JSON_QUESTION]; //get the question text
        qaNode.option1Text = jsonArray[jsonIndex][JSON_OPT1_TEXT]; //get the text for option1
        qaNode.option2Text = jsonArray[jsonIndex][JSON_OPT2_TEXT]; //get the text for option2

        currentNode = qaNode; //make the current node the node we just set up from the JSON
    }

    void UpdateUI(QANode node) //update the UI gameObjects to match the info in the node passed to this function
    {
        questionText.text = node.questionText;
        option1Text.text = node.option1Text;
        option2Text.text = node.option2Text;
    }
}