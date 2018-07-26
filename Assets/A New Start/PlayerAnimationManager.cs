using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

	public Animator animator;
	private PlayerHandCollider front_hand;
	private PlayerHandCollider back_hand;
	private PlayerSoundManager psm;

	// Use this for initialization
	void Start () {
		PlayerHandCollider[] hand_colliders = this.GetComponentsInChildren<PlayerHandCollider> ();
		for (int i = 0; i < hand_colliders.Length; i++) {
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.FRONT) {
				front_hand = hand_colliders [i];
			}
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.BACK) {
				back_hand = hand_colliders [i];
			}
		}
		animator = this.GetComponent<Animator> ();
		psm = this.GetComponent<PlayerSoundManager> ();

		if (animator) {
			Debug.Log ("Anuimator exits");
		} else {
			Debug.Log ("Animator does not exist");
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void enable_front_hand_collider(){
		animator.SetBool ("front_hand_collider_enabled", true);
		front_hand.set_front_hand_collider (true);
	}

	public void disable_front_hand_collider(){
		animator.SetBool ("front_hand_collider_enabled", false);
		front_hand.set_front_hand_collider (false);
	}

	public void set_front_hand_collider_enabled(bool val){
		animator.SetBool ("front_hand_collider_enabled", val);
	}

	public void trigger_jab(){
		if (animator.GetBool ("jab")) {
			animator.SetBool ("jab_qued", true);
		}
		animator.SetBool (PlayerAnimatorParameters.jab_bool_id, true);
	}

	public void trigger_death(){
		animator.SetTrigger (PlayerAnimatorParameters.death_trigger_id);
		psm.jab_land_fx ();
	}

	public void trigger_revive(){
		animator.SetTrigger (PlayerAnimatorParameters.revive_trigger_id);
	}

	public void trigger_jump(){
		animator.SetTrigger (PlayerAnimatorParameters.jumping_bool_id);
	}

	public void trigger_landing(){
		animator.SetBool (PlayerAnimatorParameters.jumping_bool_id, false);
	}

	private void run(){
		if(!animator.GetBool(PlayerAnimatorParameters.running_bool))
			animator.SetBool (PlayerAnimatorParameters.running_bool, true);
	}

	public void run_left(){
		run ();
		face_left ();
	}

	public void run_right(){
		run ();
		face_right ();
	}

	public void stop_running(){
		if(animator.GetBool(PlayerAnimatorParameters.running_bool))
			animator.SetBool (PlayerAnimatorParameters.running_bool, false);
	}

	public void face_left(){
		animator.SetBool (PlayerAnimatorParameters.is_facing_right, false);
		animator.SetBool (PlayerAnimatorParameters.is_facing_left, true);
	}

	public void face_right(){
		animator.SetBool (PlayerAnimatorParameters.is_facing_left, false);
		animator.SetBool (PlayerAnimatorParameters.is_facing_right, true);
	}

}
