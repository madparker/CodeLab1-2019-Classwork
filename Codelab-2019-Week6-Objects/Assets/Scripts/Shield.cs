using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

	protected float duration = 3;
	protected float damageMod = 0.5f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Timer();
		print("I'm Shield's Update");
	}

	public virtual void Timer()
	{
		if (duration > 0)
		{
			duration -= Time.deltaTime;
		}
		else
		{
			print("Destroyed Shield");
			Destroy(this);
		}
	}

	public virtual float ReduceDamage(float damage)
	{
		return damage * damageMod;
	}
}
