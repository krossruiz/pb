using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravRBCollider : MonoBehaviour {

	private PlayerMovementManager pmm;
	private PlayerAnimationManager pam;
	private PlayerHandCollider front_hand;
	private PlayerHandCollider back_hand;

	// Use this for initialization
	void Start () {
		pmm = this.GetComponent<PlayerMovementManager> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager> ();
		PlayerHandCollider[] hand_colliders = this.GetComponentsInChildren<PlayerHandCollider> ();
		for (int i = 0; i < hand_colliders.Length; i++) {
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.FRONT)
				front_hand = hand_colliders [i];
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.BACK)
				back_hand = hand_colliders [i];
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		
		List<string> collision_collider_names = new List<string>();
		for (int i = 0; i < col.contacts.Length; i++) {
			if (
				(col.contacts [i].thisCollider.enabled) && 
				(col.contacts[i].thisCollider.name == gameObject.name) &&
				!collision_collider_names.Contains(col.collider.name)
			) {
				Debug.Log ("Grav RB Colliding with " + col.collider.name);
				if (col.collider.name == "left_hand") {
					col.contacts [i].thisCollider.GetComponent<PlayerMovementManager>().request_death();
				}
				collision_collider_names.Add (col.collider.name);
			}
		}

		pmm.request_landing ();
	}
}
