using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorptionShield : Shield {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Timer();
	}

	public override float ReduceDamage(float damage)
	{
		return -damage;
	}
}
