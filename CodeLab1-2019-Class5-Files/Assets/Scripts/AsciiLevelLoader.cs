using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		string filePath = Application.dataPath + "/level0.txt"; //filePath

		if (!File.Exists(filePath)) //if file the does not exists
		{
			File.WriteAllText(filePath, "X"); //make a file with a single X in it
		}

		string[] inputLines = File.ReadAllLines(filePath); //Get all the lines from the file

		for (int y = 0; y < inputLines.Length; y++) //Loop to go through all the lines
		{
			string line = inputLines[y]; //Hmmmm? What should happen here

			for (int x = 0; x < line.Length; x++)
			{
				if (line[x] == 'X')
				{
					//make a wall
					GameObject newWall = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
					newWall.transform.position = new Vector2(x - line.Length / 2f, inputLines.Length/2f - y);
				} else if (line[x] == 'P')
				{
					//mae a player
					GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
					player.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
				}

				/*
				//if you want to use Switch statements, comment in this code
				GameObject tile; //create a variable tile
				
				switch (line[x])  //Switch checks the variable: line[x]
				{
					case 'X': //if line[x] == 'X'
						tile = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
						break;
					case 'P': //if line[x] == 'P'
						tile = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
						break;
					case 'G': //if line[x] == 'G'
						tile = Instantiate(Resources.Load("Prefabs/Goal")) as GameObject;
						break;
					case 'T': //if line[x] == 'T'
						tile = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
						break;
					default: //if line[x] doesn't match the above cases
						tile = null;
						break;
				}

				if (tile != null)
				{
					tile.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
				}
				*/

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
