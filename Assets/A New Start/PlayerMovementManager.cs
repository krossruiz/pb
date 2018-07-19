using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

	private Animator animator;
	private PlayerAnimationManager pam;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void request_jab(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jab_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_punch_state_id)
		) {
			pam.trigger_jab ();
		}
	}

	public void request_death(){
		if (!animator.GetCurrentAnimatorStateInfo(PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.death_state_id)) {
			pam.trigger_death ();
		}
	}

	public void request_revive(){
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.death_state_id)) {
			pam.trigger_revive ();	
		}
	}

	public void request_jump(){
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id)) {
			pam.trigger_jump ();	
		}
	}

	public void request_landing(){
		if(animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName(PlayerAnimatorStates.jump_state_id)){
			pam.trigger_landing ();
		}
	}

	public void request_run(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)
		){
			pam.run ();	
		}
	}

	public void request_stop_running(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)) {
			pam.stop_running ();	
		} else {
			Debug.Log ("Tf?");
		}
	}
}
