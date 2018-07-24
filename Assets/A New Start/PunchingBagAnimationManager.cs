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
		if (col.collider.name == "left_hand") {
			Debug.Log ("You hit me!");
		}
	}
}
