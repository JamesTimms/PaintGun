using UnityEngine;
using System.Collections;

public class PlayerEvtManager : MonoBehaviour {
	
		
	//The jump behaviours.
	public delegate Vector3 JumpEvent();
	public static event JumpEvent BeforeJump;
	public static event JumpEvent OverrideJump;	
	public static event JumpEvent AfterJump;	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
