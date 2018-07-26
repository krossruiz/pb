using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravRBCollider : MonoBehaviour {

	private PlayerMovementManager pmm;
	private PlayerAnimationManager pam;
	private PlayerScoreManager p_score_m;
	private PlayerHandCollider front_hand;
	private PlayerHandCollider back_hand;
	private PlayerSoundManager p_sound_m;

	private Animator animator;

	public GameObject explosion_particles;

	// Use this for initialization
	void Start () {
		pmm = this.GetComponent<PlayerMovementManager> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager> ();
		p_score_m = this.GetComponent<PlayerScoreManager> ();
		p_sound_m = this.GetComponentInChildren<PlayerSoundManager> ();
		PlayerHandCollider[] hand_colliders = this.GetComponentsInChildren<PlayerHandCollider> ();
		for (int i = 0; i < hand_colliders.Length; i++) {
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.FRONT)
				front_hand = hand_colliders [i];
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.BACK)
				back_hand = hand_colliders [i];
		}
		animator = this.GetComponentInChildren<Animator> ();
		Debug.Log (animator);

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
					Animator other_animator = col.collider.transform.parent.parent.GetComponent<Animator> ();

					if (!animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.death_state_id)) {
						if (other_animator.GetBool (PlayerAnimatorParameters.is_facing_left)) {
							Instantiate (explosion_particles, col.contacts[i].point, Quaternion.Euler(new Vector3(0,0,90)));
						};
						if (other_animator.GetBool (PlayerAnimatorParameters.is_facing_right)) {
							Instantiate (explosion_particles, col.contacts[i].point, Quaternion.Euler(new Vector3(0,0,-90)));
						};
					}

				}
				if (col.collider.name == "OutOfBounds") {
					p_sound_m.play_out_of_bounds_fx ();
					p_score_m.decrement_score ();
					pmm.request_reset_position ();
				}
				collision_collider_names.Add (col.collider.name);
			}
		}

		pmm.request_landing ();
	}
}
