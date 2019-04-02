using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QAManager : MonoBehaviour
{

    public Text questionText;
    public Text option1Text;
    public Text option2Text;
	
    QANode currentNode;
	
    // Use this for initialization
    void Start () {
        string fileLocation = Application.dataPath + "/QAPage1.json";

//		WriteNewJson(fileLocation);  //This was to initially build our Json file, use this if it gets deleted
        ReadFromJson(fileLocation);
		
        UpdateUI(currentNode);
    }

    void WriteNewJson(string fileLocation)
    {
        currentNode = new QANode(
            1, 
            "You come to a fork in the road.\n Do you got left or right?",
            "left",
            "right");
		
//		currentNode.pageNumber = 1;
//		currentNode.questionText = "You come to a fork in the road.\n Do you got left or right?";
//		currentNode.option1Text = "left";
//		currentNode.option2Text = "right";

        string jsonStr = JsonUtility.ToJson(currentNode, true);

        print(jsonStr);
	
        File.WriteAllText(fileLocation, jsonStr);
    }

    public void ChooseOption(int optionNum)
    {
        string fileLocation = Application.dataPath + "/QAPage" + currentNode.option1Page + ".json";

        
        if (optionNum != 1)
        {
            fileLocation = Application.dataPath + "/QAPage" + currentNode.option2Page + ".json";
        }
        
        ReadFromJson(fileLocation);
        UpdateUI(currentNode);
    }

    void ReadFromJson(string fileLocation)
    {
        string input = File.ReadAllText(fileLocation);
        
        print(input);

        currentNode = JsonUtility.FromJson<QANode>(input);
    }

    // Update is called once per frame
    void Update () {
		
    }

    void UpdateUI(QANode node)
    {
        questionText.text = node.questionText;
        option1Text.text = node.option1Text;
        option2Text.text = node.option2Text;
    }
}