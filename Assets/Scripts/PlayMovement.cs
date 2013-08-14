using UnityEngine;
using System.Collections;
using System;

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
	public GameObject defaultGunPrefab;
	
	/// <summary>
	/// Occurs when the player jumps.
	/// Can be used in such a way that if the player
	/// is standing on an object like a panel the
	/// object can have a triggered method added to
	/// this event. This would allow for an object
	/// to make the player jump higher.
	/// </summary>
	public event EventHandler OnJump;
	
	public event EventHandler OnShootGun;
	
	/// <summary>
	/// Occurs when the player jumps.
	/// Can be used in such a way that if the player
	/// is standing on an object like a panel the
	/// object can have a triggered method added to
	/// this event. This would allow for an object
	/// to make the player jump higher.
	/// </summary>
	public event EventHandler OnJump;
	
	/**
	 * The camera rotation range in degrees. 
	 * The camera cannot move more than this
	 * range were the start angle is 0.
	 */
	public float cameraRotRange = 60.0f;
	[HideInInspector]
	public float verticalVelocity = 0;
	[HideInInspector]
	public CharacterController cc;
	
<<<<<<< HEAD
	//Private variables.
	Camera playerCam;
	public ProjectilePos playerGun;
	float verticalRot = 0;
=======
	[HideInInspector]
	public float verticalVelocity = 0;
	[HideInInspector]
	public CharacterController cc;
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
<<<<<<< HEAD
		Physics.IgnoreLayerCollision(8, 11);
		if(playerCam = this.GetComponentInChildren<Camera>())
			Debug.LogError("Cannot find the player's camera.");
=======
		
		toggleNormalJump(true);
	}
	
	public void toggleNormalJump(bool on)
	{
		if(on)
			OnJump += NormalJump;
		else
			OnJump -= NormalJump;
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
	}
	
	//Player Physics goes here.
	void FixedUpdate () {
		
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
		
//		//Player Jump
//		if(cc.isGrounded){
//			//GetButtonDown causes a lack of bunny hopping. :(
//			if(Input.GetButton("Jump")){
//				verticalVelocity += jump.ActivateJump();
//			}
//		}else{
//			verticalVelocity += Physics.gravity.y * Time.deltaTime;
//		}
		
		//Subscribe player to all and any Jump behaviours.
		if(cc.isGrounded){
			if(Input.GetButton("Jump"))
				if(OnJump != null)
					OnJump(this, EventArgs.Empty);
<<<<<<< HEAD
				else
					NormalJump();
		}else{
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}	
		
		if(OnShootGun != null)
			OnShootGun(this, EventArgs.Empty);
		else
		{
			playerGun.PlayerUpdateGun(null, null);
//			createDefaultGun();
//			Debug.Log("Player has no gun/weapon. Creating default.");
		}
//			playerGun.PlayerUpdateGun();
		
=======
		}else{
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}	
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
		//Subscribe to player shoot.
		//shoot.FireWeapon();
		//shoot.createParticle();
		//shoot.processObjCol();
		
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;	
		cc.Move( speed * Time.deltaTime);
	}
	
<<<<<<< HEAD
	void createDefaultGun()
	{
		GameObject gun = NGUITools.AddChild(this.playerCam.gameObject, defaultGunPrefab);
		gun.transform.localRotation = new Quaternion(-90, 0, 0, 1);
		playerGun = gun.GetComponentInChildren<ProjectilePos>();
		playerGun.toggleDefaultShoot(this, true);
	}
	

	void NormalJump()
=======

	void NormalJump(object sender, EventArgs e)
>>>>>>> 32e029c6200f7e009fe619204b819a467ea25b10
	{
//		PlayMovement player = (PlayMovement) sender;
		
		//GetButtonDown causes a lack of bunny hopping. :(
		verticalVelocity = jumpSpeed;

	}
}
