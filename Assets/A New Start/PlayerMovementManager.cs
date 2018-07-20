using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour {

	public float running_force_magnitude = 113.3f;
	public float max_speed = 7.7f;

	private Rigidbody rb;
	private Animator animator;
	private PlayerAnimationManager pam;
	public CharacterFacingDirections initial_facing_direction = CharacterFacingDirections.FACING_RIGHT;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		animator = this.GetComponentInChildren<Animator> ();
		pam = this.GetComponentInChildren<PlayerAnimationManager>();

		switch(initial_facing_direction){
		case(CharacterFacingDirections.FACING_LEFT):
			animator.SetBool (PlayerAnimatorParameters.is_facing_left, true);
			break;
		case(CharacterFacingDirections.FACING_RIGHT):
			animator.SetBool (PlayerAnimatorParameters.is_facing_right, true);
			break;
		default:
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
			jab ();
		}
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_state_id) &&
			animator.GetBool(PlayerAnimatorParameters.enable_jump_punch)){
			jab ();
		}
		if(
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jab_state_id) &&
			!animator.GetBool (PlayerAnimatorParameters.enable_ground_jab_cooldown)
		){
			jab ();
		}
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.jump_punch_state_id) &&
			!animator.GetBool (PlayerAnimatorParameters.enable_jump_jab_cooldown)) {
			jab ();
		}
	}

	private void jab(){
		pam.trigger_jab ();
	}

	public void request_death(){
		if (!animator.GetCurrentAnimatorStateInfo(PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.death_state_id)) {
			death ();
		}
	}

	private void death(){
		pam.trigger_death ();
	}

	public void request_revive(){
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.death_state_id)) {
			revive ();
		}
	}

	private void revive(){
		pam.trigger_revive ();
	}

	public void request_jump(){
		if (animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id)) {
			jump ();
		}
	}

	private void jump(){
		pam.trigger_jump ();
	}

	public void request_landing(){
		if(animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName(PlayerAnimatorStates.jump_state_id)){
			landing ();
		}
	}

	private void landing(){
		pam.trigger_landing ();
	}

	public void request_run_left(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)
		){
			run_left ();
		}
	}

	private void run_left(){
		if(animator.GetBool(PlayerAnimatorParameters.is_facing_right))
			this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		if (Mathf.Abs (rb.velocity.x) < max_speed)
			rb.AddForce (running_force_magnitude * Vector3.left);
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

	private void run_right(){
		if(animator.GetBool(PlayerAnimatorParameters.is_facing_left))
			this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
		if (Mathf.Abs (rb.velocity.x) < max_speed)
			rb.AddForce (running_force_magnitude * Vector3.right);
		pam.run_right ();
	}

	public void request_stop_running(){
		if (
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.idle_state_id) ||
			animator.GetCurrentAnimatorStateInfo (PlayerAnimatorStates.default_anim_layer_index).IsName (PlayerAnimatorStates.running_state_id)) {
			stop_running ();
		}
	}

	private void stop_running(){
		pam.stop_running ();
	}
}
