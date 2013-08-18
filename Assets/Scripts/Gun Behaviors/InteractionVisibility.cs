using UnityEngine;
using System.Collections;
using System;

public class InteractionVisibility : MonoBehaviour {
	
	//NOT USED IN GAME
	public float timeTillReset;
	public bool startInvisible;
	
	InteractionGunShot gunShotManager;
	MeshRenderer myRenderer;
	void Start () {
		gunShotManager = gameObject.AddComponent<InteractionGunShot>();
		myRenderer = gameObject.GetComponent<MeshRenderer>();
		gunShotManager.OnHit += toggleMeshRenderer;
		myRenderer.enabled = !startInvisible;
		Physics.IgnoreLayerCollision(8, 10, startInvisible);
	}
	
	void toggleMeshRenderer(object sender, EventArgs e)
	{
		myRenderer.enabled = startInvisible;
		Physics.IgnoreLayerCollision(8, 10, !startInvisible);
		if(timeTillReset <= 0.0f)
		{
			timeTillReset = 1.0f;
			Debug.LogWarning("timeTillReset has to be more than 0.");
		}
//		if(IsInvoking("turnPlayerInteractionOn"))
//			CancelInvoke("turnPlayerInteractionOn");
		Invoke("turnPlayerInteractionOn", timeTillReset);
	}
	
	void turnPlayerInteractionOn()
	{
		Physics.IgnoreLayerCollision(8, 10, startInvisible);
		myRenderer.enabled = !startInvisible;
		
	}
	
}
