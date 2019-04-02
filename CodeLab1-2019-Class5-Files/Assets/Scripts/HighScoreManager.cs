using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{

	public List<string> hsNames;
	public List<int> hsScores;
	
	// Use this for initialization
	void Start ()
	{
		string filePath = Application.dataPath + "/highScore.txt";

		if (!File.Exists(filePath)) //if the file does not exist
		{
			//create a file
			string output = "";

			for (int i = 0; i < 10; i++)
			{
				output += "Matt:" + (10 - i) + '\n';
			}
			
			Debug.Log("output: " + output);

			File.WriteAllText(filePath, output);
		}
		
		hsNames = new List<string>();
		hsScores = new List<int>();
		
		//if the file does exist,read file
		string[] inputLines = File.ReadAllLines(filePath); //get each line in the file
		for (int i = 0; i < inputLines.Length; i++) //loop through lines
		{
			string line = inputLines[i]; //ex: "Matt:10"
			string[] splitLine = line.Split(':'); //ex: "Matt" | "10"
			string name = splitLine[0]; //ex: "Matt"
			int score = Int32.Parse(splitLine[1]); //ex: 10	

			hsNames.Add(name); //put name in my list of names
			hsScores.Add(score); //put score in my list of scores
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
