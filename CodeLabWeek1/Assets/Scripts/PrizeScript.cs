using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) //if the collider that hit us has a tag "Player"
		{
			other.gameObject.GetComponent<PlayerController>().score++; //Get the PlayerController and add 1 to it's score
		}

		Destroy(gameObject); //Destroy the gameObject I am attached to
	}
}
