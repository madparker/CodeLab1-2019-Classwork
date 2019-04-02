using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode rightKey;
	public KeyCode leftKey;

	public float forceAmount = 1;

	Rigidbody2D rb;

	public int score = 0;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
	{

		Vector2 newForce = new Vector2(0, 0); //the force we will add to our player

		if (Input.GetKey(upKey)) //When someone presses "W"
		{
			Debug.Log("Pressed W");
			newForce.y += forceAmount;
		}

		if (Input.GetKey(downKey))
		{
			newForce.y -= forceAmount;
		}

		if (Input.GetKey(leftKey))
		{
			newForce.x -= forceAmount;
		}

		if (Input.GetKey(rightKey))
		{
			newForce.x += forceAmount;
		}

		rb.AddForce(newForce);
	}
}
