using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public float health = 100f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Damage(10);
		}
	}

	void Damage(float damageAmount)
	{
		Shield armor = GetComponent<Shield>();

		if (armor != null)
		{
			print("Got a shield!!!");
			damageAmount = armor.ReduceDamage(damageAmount);
		}
		else
		{
			print("Sorry, not shield for you :(");
		}

		health -= damageAmount;
	}
}
