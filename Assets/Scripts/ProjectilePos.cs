using UnityEngine;
using System.Collections;
using System;

public class ProjectilePos: MonoBehaviour {
	
	public LineRenderer projectile;
	public InteractionGunShot gunManager;
	public float fireRate;
	RaycastHit hit;
	float counter;
	
	public void toggleDefaultShoot(PlayMovement player, bool on)
	{
		if(on)
			player.OnShootGun += PlayerUpdateGun;
		if(!on)
			player.OnShootGun -= PlayerUpdateGun;
	}
	
	public void PlayerUpdateGun (object sender, EventArgs e) 
	{
		Vector3 projectilePos 	= transform.position;
		Vector3 fwd 			= transform.TransformDirection( Vector3.forward );
		if (((Input.GetMouseButton( 0 ) && counter > ((1/fireRate) * Time.deltaTime))) ||
			 Input.GetMouseButtonDown( 0 ))
		{
			setPosition( projectilePos, fwd);
			
			if ( Physics.Raycast( projectilePos, fwd, out hit, Mathf.Infinity ) )
			{
				InteractionGunShot gunShot = hit.collider.gameObject.GetComponent<InteractionGunShot>( );
				if( gunShot != null) {
					gunShot.SendMessage( "OnGunHit" );
				}
			}
			counter = 0.0f;
		}		
		else if ( (Input.GetMouseButton( 1 ) && counter > ( (1/fireRate) * Time.deltaTime) ) ||
			 Input.GetMouseButtonDown( 1 ) )
		{			
			setPosition(  projectilePos, fwd);
			if ( Physics.Raycast( projectilePos, fwd, out hit, Mathf.Infinity ) )
			{
				InteractionGunShot rightGunShot = hit.collider.gameObject.GetComponent<InteractionGunShot>( );
				if ( rightGunShot != null ){
					rightGunShot.SendMessage( "OnGunHitRight" );
				}
			}
			counter = 0.0f;
		}
		counter += Time.deltaTime;
	}
	
	void setPosition( Vector3 x, Vector3 y ){
		const int lineRange = 1000;
		projectile.SetPosition( 0, x );
		projectile.SetPosition( 1, ( y * lineRange ) );
		Instantiate( projectile, x , transform.rotation );
	}
	
}