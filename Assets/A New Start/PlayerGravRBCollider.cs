﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravRBCollider : MonoBehaviour {

	private PlayerMovementManager pmm;
	private PlayerAnimationManager pam;

	// Use this for initialization
	void Start () {
		pmm = this.GetComponent<PlayerMovementManager> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		ContactPoint[] contacts = col.contacts;
		for (int i = 0; i < col.contacts.Length; i++) {
			Debug.Log (contacts [0].otherCollider.gameObject);
		}
		pam.trigger_landing ();
		Debug.Log ("hello");
	}
}
