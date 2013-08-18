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
	
	}
	
	void objectGrow( object sender, EventArgs e )
	{	
		growShrinkSwitch = false;
		activate = true;
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
}
//	
//	void MyPewPewMethod()
//	{
//		Debug.Log ("pew pew");
//		
//		CancelInvoke("MyPewPewMethod");
//	}

