using UnityEngine;
using System.Collections;

public class EndTheGame : MonoBehaviour {
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			Invoke("EndGame", 5.0f);
		}
	}
	
//	public void OnTriggerExit(Collider col)
//	{
//		if(col.tag == "Player")
//		{
////			EndGame();
//		}
//	}

	void EndGame()
	{
		Application.LoadLevel(2);
	}
	
}
