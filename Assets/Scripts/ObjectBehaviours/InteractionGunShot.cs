using UnityEngine;
using System.Collections;
using System;

public class InteractionGunShot : MonoBehaviour {

	public event EventHandler OnHit;
	public event EventHandler OnRightHit;
	void OnGunHit( )
	{
		if( OnHit != null ){
			OnHit( this, EventArgs.Empty );
		}else{
			Debug.Log( "No events for OnGunHit: " + this.name );
		}
	}
	void OnGunHitRight( )
	{
		if( OnRightHit != null ){
			OnRightHit( this, EventArgs.Empty);	
		}else{
			Debug.Log( "Right trigger!" );
		}
	}
	
}
