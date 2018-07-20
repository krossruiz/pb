using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

	public float gravity_magnitude = 9.8f;

	// Use this for initialization
	void Start () {
		Physics.gravity = Vector3.down * gravity_magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
