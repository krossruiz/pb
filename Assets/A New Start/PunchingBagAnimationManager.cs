using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBagAnimationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (col.collider.name);

		if (col.collider.name == "left_hand") {
			Debug.Log ("You hit me!");
		}

		//List<string> collision_collider_names = new List<string>();
		//for(int i = 0; i < col.contacts.Length; i++){
		//	string collider_name = col.contacts [i].otherCollider.name;
		//	if (!collision_collider_names.Contains (collider_name)) {
		//		collision_collider_names.Add (collider_name);
		//	}
		//	else {
		//	}
		//}
		//for (int i = 0; i < collision_collider_names.Count; i++) {
		//	Debug.Log (collision_collider_names[i]);
		//}
	}
}
