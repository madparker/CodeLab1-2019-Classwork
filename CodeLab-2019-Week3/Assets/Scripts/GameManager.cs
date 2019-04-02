using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	int health;
	public int Health
	{
		get { return health; }
		set
		{
			health = value;
			if (health > 100)
			{
				health = 100;
			}

			if (health < 0)
			{
				health = 0;
			}
		}
	}

	int score = 0;
	public int Score
	{
		get
		{
			//print("Someone got the score");
			return score;
		}
		set
		{
			score = value;
			print("score now equals: " + score);
		}
	}

	public static GameManager instance;

	// Use this for initialization
	void Start ()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Score++;
		
		//print("Your currect score is: " + Score);
	}
}
