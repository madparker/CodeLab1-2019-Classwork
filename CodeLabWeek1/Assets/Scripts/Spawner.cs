using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("Spawn", 3, 0.5f); //Call Spawn after 3 seconds and then every half second
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
		GameObject newPrize = Instantiate(Resources.Load<GameObject>("Prefab/Prize"));
		newPrize.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
	}
}
