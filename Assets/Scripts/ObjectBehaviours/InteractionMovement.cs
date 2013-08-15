using UnityEngine;
using System.Collections;
using System;

public class InteractionMovement : MonoBehaviour {

	public void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			PlayMovement player = col.gameObject.GetComponent<PlayMovement>();
			player.OnTouchObj += SpeedMovement;
		}
	}
	
	public void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			PlayMovement player = col.gameObject.GetComponent<PlayMovement>();
			player.OnTouchObj -= SpeedMovement;
		}
	}
	
	void SpeedMovement(object sender, EventArgs e)
	{
		PlayMovement player = (PlayMovement)sender;
		
		//forward backward movement.
		float forwardSpeed = PlayMovement.movementSpeed * Input.GetAxis("Vertical");
		//Left Right movement.
		float sideSpeed = PlayMovement.movementSpeed * Input.GetAxis("Horizontal");	
		
		Vector3 speed = new Vector3(sideSpeed, player.verticalVelocity, forwardSpeed);
		speed = player.transform.rotation * speed;	
		player.cc.Move( speed * Time.deltaTime);
	}
}
