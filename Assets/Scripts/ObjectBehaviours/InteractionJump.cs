using UnityEngine;
using System.Collections;
using System;

public class InteractionJump : MonoBehaviour {
	
	public float jumpPower;
	
	PlayMovement player;
	
	/// <summary>
	/// Raises the trigger enter event for player.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
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
		if(col.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayMovement>();
			player.OnJump -= SuperJump;
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
			player.verticalVelocity = jumpPower * PlayMovement.jumpSpeed;
		}
	}
}
