using UnityEngine;
using System.Collections;
using System;

public class InteractionChangeSize : MonoBehaviour {
	public float xSize;
	public float ySize;
	public float zSize; 
	bool growShrinkSwitch 	= true;
	bool activate 			= false;
	InteractionGunShot gunShotManager;
	void Start ( ) {
		const float setRange			= 10.0f;
		xSize 							= xSize / setRange;
		zSize 							= zSize / setRange; //change out of start
		ySize 							= ySize + zSize;
		gunShotManager 					= gameObject.AddComponent<InteractionGunShot>();
		gunShotManager.OnHit			+= objectGrow;
		gunShotManager.OnRightHit		+= objectShrink;
	}
	
	void objectShrink( object sender, EventArgs e)
	{
		growShrinkSwitch = true;
		activate = true;
//		float animateX = Mathf.Lerp (transform.localScale.x, (xSize/10), 5.0f );
//		float animateY = Mathf.Lerp (transform.localScale.y, (ySize/10), 5.0f );
//		float animateZ = Mathf.Lerp (transform.localScale.z, (zSize/10), 5.0f );
//		Vector3 newVector3 = new Vector3(xSize/10, ySize/10, zSize/10);
//		transform.localScale = Vector3.Lerp(transform.localScale, newVector3, 5.0f);
	
	}
	
	void objectGrow( object sender, EventArgs e )
	{	
		growShrinkSwitch = false;
		activate = true;
//		Vector3 newVector3 = new Vector3(xSize/10, ySize/10, zSize/10);
//		transform.localScale = Vector3.Lerp(transform.localScale, -newVector3, 5.0f);
//		InvokeRepeating("MyPewPewMethod", 1.0f, 0.5f);
	}
	void Update( ){
		
		
		if (activate){
		
		float animateX;
		float animateY;
		float animateZ;
		if ( growShrinkSwitch ){
			animateX = Mathf.Lerp (transform.localScale.x, (xSize/5), Time.deltaTime );
			animateY = Mathf.Lerp (transform.localScale.y, (ySize/5), Time.deltaTime );
			animateZ = Mathf.Lerp (transform.localScale.z, (zSize/5), Time.deltaTime );
		}else{
			animateX = Mathf.Lerp (transform.localScale.x, xSize, Time.deltaTime );
			animateY = Mathf.Lerp (transform.localScale.y, ySize, Time.deltaTime );
			animateZ = Mathf.Lerp (transform.localScale.z, zSize, Time.deltaTime );
//			transform.localScale = new Vector3( animateX, animateY, animateZ);
		}
			
		transform.localScale = new Vector3( animateX, animateY, animateZ );
		//transform.localScale = new Vector3( (float)Math.Round(animateX, 2 ), (float) Math.Round (animateY, 2 ), (float) Math.Round(animateZ, 2 ));
		if (animateX == xSize){
				activate = false;
			}
		}
	}
//	
//	void MyPewPewMethod()
//	{
//		Debug.Log ("pew pew");
//		
//		CancelInvoke("MyPewPewMethod");
//	}
}

