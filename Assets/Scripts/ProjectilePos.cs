using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using System;

public class ProjectilePos: MonoBehaviour {
	
	public LineRenderer projectile;
	public InteractionGunShot gunManager;
	public float fireRate;
	RaycastHit hit;
	
	float fireRateSensitivity = 0.1f;
	
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
			projectile.SetPosition( 0, transform.position );
			projectile.SetPosition( 1, (fwd * 1000) );
			Instantiate( projectile, projectilePos , transform.rotation );	
			
			if ( Physics.Raycast( projectilePos, fwd, out hit, Mathf.Infinity ) )
			{
				InteractionGunShot gunShot = hit.collider.gameObject.GetComponent<InteractionGunShot>();
				if(gunShot != null)
					gunShot.SendMessage("OnGunHit");
			}
			counter = 0.0f;
		}		
		else if ((Input.GetMouseButton( 1 ) && counter > ((1/fireRate) * Time.deltaTime)) ||
			 Input.GetMouseButtonDown( 1 ))
		{			
			projectile.SetPosition( 0, transform.position );
			projectile.SetPosition( 1, (fwd * 1000) );
			Instantiate( projectile, projectilePos , transform.rotation );		
			
			if ( Physics.Raycast( projectilePos, fwd, out hit, Mathf.Infinity ) )
			{
				InteractionGunShot gunShot = hit.collider.gameObject.GetComponent<InteractionGunShot>();
				if(gunShot != null)
					gunShot.SendMessage("OnGunHitRight");
			}
			counter = 0.0f;
		}
		counter += Time.deltaTime;
=======

public class ProjectilePos: MonoBehaviour {
	public LineRenderer projectile;
	void Update ( ) {
		const float range 		= 500f;
		Vector3 projectilePos 	= transform.position;
		Vector3 fwd 			= transform.TransformDirection( Vector3.forward );
		RaycastHit hit = new RaycastHit();
		Debug.DrawRay( projectilePos, fwd ); //remove after development
		if ( Input.GetMouseButtonDown( 0 ) ){			
			projectile.SetPosition( 0, transform.position );
			projectile.SetPosition( 1, (fwd * 1000) );
			Instantiate( projectile, projectilePos , transform.rotation );
		}
		if ( Physics.Raycast( projectilePos, fwd, out hit, range ) ){
			Debug.Log ( "There be something" );
		}
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
	}
}