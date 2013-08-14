using UnityEngine;
using System.Collections;
using System;

public class InteractionElevator : MonoBehaviour {

	public Moveable moveable;
	public Vector3 velocity;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			moveable.gameObject.rigidbody.velocity += velocity;
//			moveable.OnMove += Elevate;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			moveable.gameObject.rigidbody.velocity -= velocity;
//			moveable.OnMove -= Elevate;
		}
	}
	
	void Elevate(object sender, EventArgs e)
	{
		if(sender is Moveable)
		{
//			Moveable movable = (Moveable)sender;
			//World coordinates.
			moveable.gameObject.rigidbody.velocity += velocity;
			moveable.OnMove -= Elevate;
		}
	}
	
}
