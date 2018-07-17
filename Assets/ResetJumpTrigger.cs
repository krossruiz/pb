using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJumpTrigger : MonoBehaviour {

	public string collider_name = "";
	private Collider collider;

	// Use this for initialization
	void Start () {
		collider = this.GetComponent<Collider> ();
		collider.name = collider_name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
