using UnityEngine;
using System.Collections;
using System;

public class InteractionJump : MonoBehaviour {

	PlayMovement player;
	
	/// <summary>
	/// Raises the trigger enter event for player.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	void OnTriggerEnter(Collider col)
	{
<<<<<<< HEAD
		if(col.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
=======
		if(col.gameObject.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
			player.toggleNormalJump(false);
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
			player.OnJump += SuperJump;
		}
	}
	
	/// <summary>
	/// Raises the collision exit event for player.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	void OnTriggerExit(Collider col)
	{
<<<<<<< HEAD
		if(col.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
			player.OnJump -= SuperJump;
=======
		if(col.gameObject.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
			player.OnJump -= SuperJump;
			player.toggleNormalJump(true);
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
		}
	}
	
	//Used for all non player objects.
//	void OnCollisionEnter(Collision col)
//	{
//		
//	}
//	
//	void OnCollisionExit(Collision col)
//	{
//		
//	}
	
	void SuperJump(object sender, EventArgs e)
	{
		if(sender is PlayMovement)
		{
			if(player == null)
			{
				player = (PlayMovement)sender;
				Debug.LogWarning("Super Jump isn't registering player on ColEnter properly.");
			}
			//SUPER JUMPU~~~!!
			player.verticalVelocity = 2 * player.jumpSpeed;
		}
	}
}
