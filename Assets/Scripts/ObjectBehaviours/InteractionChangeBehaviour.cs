using UnityEngine;
using System.Collections;
using System;

public class InteractionChangeBehaviour : MonoBehaviour {

	public Material materialStart;
	public Material materialEnd;
	public float timeToChange;
	public MeshRenderer meshRenderer;
	
	const float delay = 0.5f;
	PlayMovement player;
	bool flip = true;
	bool triggered = false;
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			if(!triggered)
			{
				triggered = true;
				player = col.gameObject.GetComponent<PlayMovement>();
				player.OnTouchObj += changeBehaviour;
				materialEnd.SetColor("_Color", Color.red);
				materialEnd.SetColor("_Color", Color.white);
			}
		}
	}
	
	public void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			if(triggered)
			{
				player = col.gameObject.GetComponent<PlayMovement>();
			 	player.OnTouchObj -= changeBehaviour;
				triggered = false;
			}
		}
	}
	
	void changeBehaviour(object sender, EventArgs e)
	{
		float lerp = Mathf.PingPong(Time.time, timeToChange) / timeToChange;
		
		if(flip)
		{
			meshRenderer.material.Lerp(materialStart, materialEnd, lerp);
			flip = !flip;
		}
		else
		{
//			meshRenderer.material.Lerp(materialEnd, materialStart, lerp);
			flip = !flip;
		}
			
		player.OnTouchObj -= changeBehaviour;
		//Prevent the texture from changing until after the lerp has finished.
		Invoke("reEnableChangeBehaviour",  (timeToChange + delay));
	}
	
	void reEnableChangeBehaviour()
	{
		player.OnTouchObj += changeBehaviour;
	}
	
}
