using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text scoreText;
	public Text highScoreText;

	const string PLAYER_PREF_HIGHSCORE = "highScore";
	const string FILE_HIGH_SCORE = "/MyHighScoreFile.txt";
	
	int score = 0;
	public int Score
	{
		get
		{
			return score;
		}

		set
		{
			score = value;
			scoreText.text = "Score: " + score;
			HighScore = score;
		}
	}

	int highScore = 0;
	public int HighScore
	{
		get
		{
			return highScore;
		}
		set
		{
			if (value > highScore)
			{
				highScore = value;
				highScoreText.text = "High Score: " + highScore;
//				PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, highScore);

				Debug.Log("Application.dataPath: " +  Application.dataPath);
				string fullPathToFile = Application.dataPath + FILE_HIGH_SCORE;
				
				File.WriteAllText(fullPathToFile, "HighScore: " + highScore);
			}
		}
	}

	public static GameManager instance;

	// Use this for initialization
	void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		Score = 0;
		//HighScore = PlayerPrefs.GetInt(PLAYER_PREF_HIGHSCORE, 10);

		string highScoreFileTxt = File.ReadAllText(Application.dataPath + FILE_HIGH_SCORE);

		string[] scoreSplit = highScoreFileTxt.Split(' ');
		
		HighScore = Int32.Parse(scoreSplit[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
