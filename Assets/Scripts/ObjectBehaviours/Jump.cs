using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	public float JumpStrength;
	
	// Use this for initialization
	void OnEnable()
	{
//		PlayerEvtManager.BeforeJump += beforeSuperJump;	
//		PlayerEvtManager.OverrideJump += overrideSuperJump;	
//		PlayerEvtManager.AfterJump += afterSuperJump;	
	}
	
	void OnCollisionEnter(Collision col)
	{
//		if(col.Equals(PlayMovement))
//		{
//			sPlayMovement player = (PlayMovement) col;
			
//		}	
	}
	
	public void ActivateJump(Transform trans)
	{
////		if(obj.(PlayMovement.Re))
//			if(cc.isGrounded){
//				//GetButtonDown causes a lack of bunny hopping. :(
//				if(Input.GetButton("Jump")){
//					jump.ActivateJump();
//				}
//			}else{
//				verticalVelocity += Physics.gravity.y * Time.deltaTime;
//			}
////		}
	}
}
