using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToScore : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Debug.Log("Clicked on the cube!");
		GameManager.instance.Score++;
	}
}
