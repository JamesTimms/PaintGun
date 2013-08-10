using UnityEngine;
using System.Collections;

/**
 * This require component line of code will cause a 
 * compiler error if there is no Character Controller
 * in Unity assigned to this script.
 */
[RequireComponent (typeof(CharacterController))]
public class PlayMovement : MonoBehaviour {
	
	public float movementSpeed = 7.0f;
	public float mouseSensitivity = 1.5f;
	public float jumpSpeed = 7.0f;
	
	/**
	 * The camera rotation range in degrees. 
	 * The camera cannot move more than this
	 * range were the start angle is 0.
	 */
	public float cameraRotRange = 60.0f;
	float verticalRot = 0;
	
	float verticalVelocity = 0;
	CharacterController cc;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		/** Main Camera
		 * Camera rotation based on mouse movement controls.
		 */
		
		//Horizontal camera movement.
		float rotYaw = Input.GetAxis("Mouse X") * mouseSensitivity;;
		transform.Rotate(0, rotYaw, 0);
		
		//Limit the Vertical camera movement.
		verticalRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRot = Mathf.Clamp(verticalRot, -cameraRotRange, cameraRotRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRot, 0, 0);
		
		/** Player Movement
		 * Set speed of player based on movement controls used.
		 */
		//forward backward movement.
		float forwardSpeed = movementSpeed * Input.GetAxis("Vertical");
		//Left Right movement.
		float sideSpeed = movementSpeed * Input.GetAxis("Horizontal");
		
		if(cc.isGrounded){
			//GetButtonDown causes a lack of bunny hopping. :(
			if(Input.GetButton("Jump")){
				verticalVelocity = jumpSpeed;
			}
		}else{
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;	
		cc.Move( speed * Time.deltaTime);
	}
}
