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
		Debug.Log (col.gameObject);
		if(col.gameObject.GetComponent<PunchingBagAnimationManager>())
			front_hand.set_front_hand_collider(false);
		pam.trigger_landing ();
	}
}
