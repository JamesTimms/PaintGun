using UnityEngine;
using System.Collections;
using System;

public class InteractionMovePos : MonoBehaviour {
	public bool moveHorizontal 	= false;
	public bool moveVertical 	= false;
	public bool playerToggle	= false;
	public int	waitTime		= 3; //not tested
	public int	xDistance		= 0;
	public int	yDistance		= 0;
	
	bool activate				= true;
	Transform startPosition;
	InteractionGunShot gunShotManager;
//	Vector3 startPos;
	
	void Start ( ) {
		gunShotManager 				= gameObject.AddComponent<InteractionGunShot>();
		gunShotManager.OnHit		+= moveForward;
		gunShotManager.OnRightHit	+= moveBack;
	}
	void moveForward( object sender, EventArgs e)
	{
//		startPos = transform.position;
		activate = true;
		getMovement();
	}
	void moveBack( object sender, EventArgs e)
	{
		CancelInvoke();
		activate = false;
		getMovementUp( );
	}	
	void getMovement( ){
		const float smoothMove 	= 0.0009f;
		const float moveInstant	= 0.01f;
		if (moveHorizontal){
			InvokeRepeating("moveObjectFwd", moveInstant, smoothMove);
		}
		if (moveVertical){
			InvokeRepeating("moveObjectUp", moveInstant, smoothMove);
		}
		if (transform.localPosition.x == xDistance){
			Debug.Log ("YAYAYAYAAY");
			activate = false;
		}
	}
	
	void getMovementUp( ){
		const float smoothMove 	= 0.0009f;
		const float moveInstant	= 0.01f;
		if (playerToggle){
			if (moveHorizontal){
				InvokeRepeating("moveObjectFwd", moveInstant, smoothMove);
			}
			if (moveVertical){
				InvokeRepeating("moveObjectUp", moveInstant, smoothMove);
			}
			if (transform.localPosition.y == yDistance){
				activate = false;
			}
		}
	}
	void moveObjectFwd( ){	
		if (activate){
			transform.localPosition	 	= new Vector3(Mathf.Lerp( transform.localPosition.x, xDistance, Time.deltaTime),
										transform.localPosition.y , transform.localPosition.z);
		}else{
			transform.localPosition 	= new Vector3(Mathf.Lerp(transform.localPosition.x, xDistance/10 , Time.deltaTime),
										transform.localPosition.y , transform.localPosition.z);
		}
//		if (!playerToggle){
//			Invoke("WaitTime", waitTime);
//		}
	}
	void moveObjectUp( ){
		if (activate){
			transform.localPosition 	= new Vector3( transform.localPosition.x, 
									Mathf.Lerp(transform.localPosition.y, yDistance, Time.deltaTime),
									transform.localPosition.z);
		}else{
			transform.localPosition 	= new Vector3( transform.localPosition.x, 
									Mathf.Lerp(transform.localPosition.y, -30, Time.deltaTime),
									transform.localPosition.z);
		}
	}
	void WaitTime( ){
		Debug.Log("Yay I'm Waiting!");
//		activate = false;
//		if (moveHorizontal){
//			moveObjectFwd( );
//		}
//		else{
//			moveObjectUp( );
//		}	
	}
}

