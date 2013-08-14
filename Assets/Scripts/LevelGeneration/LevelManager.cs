using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject levelGenTool;
	public GameObject level;
	
	public Vector3 Range;
	
	// Use this for initialization
	void Start () {
		//1. Create an empty game object.
		//2. Add a box collider set to trigger.
		//3. Change size of box collider to a random size based on a range.
		//4. create objects within the bounds of the box collider randomlly.*
		//5. Position and rotate the originally empty game object in some way 
		//	 so that it's usefull.
		//
		//4.* start with the object creation.
		//1. The box collider is broken up to slices were the actual interactive
		// 	 gameobject will go. The slices are used to allow for more useful
		//	 Positing of the game objects.
		//2. The slices are box collider as is triggers as well. Each slice will
		//	 be created and positioned one after the other. The slices are 
		//	 to create the desired layout for the game objects.
		
		
		//Calc positioning.
//		Transform levelTrans = level.transform;
//		Vector3 blockPosition = Vector3.zero;
//		
//		Random.Range(-(Range.x/2.0f), +(Range.x/2.0f));
//		Random.Range(-(Range.y/2.0f), +(Range.y/2.0f));
//		Random.Range(-(Range.z/2.0f), +(Range.z/2.0f));
//		
//		GameObject go = Instantiate(levelGenTool) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
