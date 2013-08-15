using UnityEngine;
using System.Collections;
using System;

public class InteractionChangeSize : MonoBehaviour {
	public float xSize;
	public float ySize;
	public float zSize; 
	public bool	ShrinkSize;
	public bool ReturnOriginal;
	public bool ReturnOnGun;
	bool GunSwitch;
	InteractionGunShot gunShotManager;
	void Start ( ) {
		const float setRange	= 10.0f;
		Vector3 origPosition	= transform.position;
		xSize 					= xSize / setRange;
		zSize 					= zSize / setRange;
		ySize 					= ySize + zSize;
		GunSwitch				= false;
		gunShotManager 			= gameObject.AddComponent<InteractionGunShot>();
		gunShotManager.OnHit	+= changeObjectSize;
		
		if (ReturnOnGun == true){
			ReturnOriginal = true;
		}
	}
	void changeObjectSize( object sender, EventArgs e )
	{	
		GunSwitch = true;
	}
	void Update( ){
		if (GunSwitch == true && ShrinkSize == true ){
			float animateX = Mathf.Lerp (transform.localScale.x, (xSize/10), Time.deltaTime );
			float animateY = Mathf.Lerp (transform.localScale.y, (ySize/10), Time.deltaTime );
			float animateZ = Mathf.Lerp (transform.localScale.z, (zSize/10), Time.deltaTime );
			transform.localScale = new Vector3( animateX, animateY, animateZ);
		}else if ( GunSwitch == true ){
			float animateX = Mathf.Lerp (transform.localScale.x, xSize, Time.deltaTime );
			float animateY = Mathf.Lerp (transform.localScale.y, ySize, Time.deltaTime );
			float animateZ = Mathf.Lerp (transform.localScale.z, zSize, Time.deltaTime );
			transform.localScale = new Vector3( animateX, animateY, animateZ);
		}
	}
}

