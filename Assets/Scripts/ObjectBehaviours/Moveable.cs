using UnityEngine;
using System.Collections;
using System;

public class Moveable : MonoBehaviour {
	
	public Vector3 defaultVelocity;
	
	public event EventHandler OnMove;
	
	//Private variables
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(OnMove != null)
			OnMove(this, EventArgs.Empty);
		else
			defaultMove();
	}
	
	void defaultMove()
	{
		gameObject.rigidbody.velocity += defaultVelocity;// * transform.rotation;
	}
}
