using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

	private Animator animator;
	private PlayerAnimationManager pam;
	public CharacterFacingDirections initial_facing_direction = CharacterFacingDirections.FACING_RIGHT;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager>();

		switch(initial_facing_direction){
		case(CharacterFacingDirections.FACING_LEFT):
			Debug.Log ("FACING LEFT");
			animator.SetBool (PlayerAnimatorParameters.is_facing_left, true);
			break;
		case(CharacterFacingDirections.FACING_RIGHT):
			Debug.Log ("FACING RIGHT");
			animator.SetBool (PlayerAnimatorParameters.is_facing_right, true);
			break;
		default:
			Debug.Log ("Where are you facing?!");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void request_jab(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id)
		) {
				pam.trigger_jab ();
		}
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_state_id) &&
			animator.GetBool(PlayerAnimatorParameters.enable_jump_punch)){
			pam.trigger_jab();
		}
		if(
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jab_state_id) &&
			!animator.GetBool (PlayerAnimatorParameters.enable_ground_jab_cooldown)
		){
			pam.trigger_jab ();
		}
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_punch_state_id) &&
			!animator.GetBool (PlayerAnimatorParameters.enable_jump_jab_cooldown)) {
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

	public void request_run_left(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)
		){
			run_left ();
		}
	}

	public void run_left(){
		if(animator.GetBool(PlayerAnimatorParameters.is_facing_right))
			this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		pam.run_left();
	}

	public void request_run_right(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)
		){
			run_right ();
		}
	}

	public void run_right(){
		if(animator.GetBool(PlayerAnimatorParameters.is_facing_left))
			this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		pam.run_right ();
	}

	public void request_stop_running(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)) {
			pam.stop_running ();	
		}
	}
}
