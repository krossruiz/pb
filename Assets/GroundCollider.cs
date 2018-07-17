using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Collider>().name = "ground";
		Physics.IgnoreLayerCollision (9, 9);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
