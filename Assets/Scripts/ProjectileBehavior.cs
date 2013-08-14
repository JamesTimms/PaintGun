using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
	public LineRenderer projectile;
	public float speed	= 100.0f;
	void Update ( ) {
		transform.Translate( Vector3.forward * 100 * Time.deltaTime );
		projectile.SetPosition( 0, transform.position );
		Destroy( gameObject, 0.5f );
		}
	}