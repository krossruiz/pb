using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBagAnimationManager : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "left_hand") {
			Debug.Log ("You hit me!");
			animator.SetTrigger ("jabbing");
		}
	}
}
