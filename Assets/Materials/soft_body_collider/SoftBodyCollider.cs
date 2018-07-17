using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBodyCollider : MonoBehaviour {
	private Collider soft_body_collider;

	// Use this for initialization
	void Start () {
		soft_body_collider = this.GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts) {
			Debug.Log (contact.thisCollider.name);
		}
	}
}
