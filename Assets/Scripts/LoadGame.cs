using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("LoadTransGun", 5.0f);
	}
	
	void LoadTransGun()
	{
		Application.LoadLevel(1);	
	}
}
