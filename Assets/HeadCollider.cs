using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

	private Collider collider;

	// Use this for initialization
	void Start () {
		collider = this.GetComponent<Collider> ();
		collider.name = "head_collider";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
