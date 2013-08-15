using UnityEngine;
using System.Collections;
using System;

public class InteractionGunShot : MonoBehaviour {

	public event EventHandler OnHit;
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
		if( OnHit !=null ){
			OnHit( this, EventArgs.Empty);	
		}else{
			Debug.Log( "Right trigger!" );
		}
	}
	
}
