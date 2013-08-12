using UnityEngine;
using System.Collections;

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
	}
}