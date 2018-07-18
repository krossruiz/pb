using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float walking_speed = 50.0f;
	public float jump_magnitude = 20.0f;
	private Animator animator;
	public float max_walking_speed = 20f;
	private GameObject armature;
	private PlayerAudio player_audio;
	public float jump_x_amplifier = 1.5f;

	public enum JumpStates {
		HAS_NOT_JUMPED,
		JUMPED_ONCE,
		JUMPED_TWICE_OR_MORE,
		LANDED
	};

	public enum MoveRequests{
		Left,
		Right,
		Jump,
		ZeroVelocity,
		Punch
	}

	public enum PlayerNumber
	{
		PLAYER_ONE,
		PLAYER_TWO
	}
	public PlayerNumber player_number;


	public enum PlayerFacingDirection
	{
		LEFT,
		RIGHT
	}
	public PlayerFacingDirection player_direction;

	public JumpStates current_jump_state = JumpStates.HAS_NOT_JUMPED;
	private Rigidbody rb;

	public Material player_mobilized;
	public Material player_immobilized;

	private MeshRenderer mesh_renderer;

	// Use this for initialization
	void Start () {
		armature = this.transform.GetChild (0).gameObject;
		switch (player_direction) {
		case(PlayerFacingDirection.LEFT):
			armature.transform.localScale = new Vector3 (
				-armature.transform.localScale.x,
				armature.transform.localScale.y,
				armature.transform.localScale.z
			);
			break;
		default:
			break;
		}
		animator = this.GetComponentInChildren<Animator> ();
		player_audio = this.GetComponent<PlayerAudio> ();
		Debug.Log (armature.name);
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void move_request_handler(MoveRequests move_request){
		switch (move_request) {
		case(MoveRequests.Jump):
			switch (current_jump_state) {

			//This case restricts player to single jump. Removal enables double jump.
			case(JumpStates.JUMPED_ONCE):
				break;

			case(JumpStates.JUMPED_TWICE_OR_MORE):
				break;
			case(JumpStates.LANDED):
				break;
			default:
				animator.SetBool ("IsJumping", true);
				jump_player ();
				break;
			}
			break;
		case(MoveRequests.Left):
			switch (current_jump_state) {
			case(JumpStates.LANDED):
				break;

			//Committed jump
			case(JumpStates.JUMPED_ONCE):
				break;
			case(JumpStates.JUMPED_TWICE_OR_MORE):
				break;

			default:
				player_audio.player_walk ();
				switch(player_direction){
				case(PlayerFacingDirection.RIGHT):
					armature.transform.localScale = new Vector3 (
						-armature.transform.localScale.x,
						armature.transform.localScale.y,
						armature.transform.localScale.z
					);
					player_direction = PlayerFacingDirection.LEFT;
					break;
				default:
					break;
				}
				animator.SetBool ("IsRunning", true);
				move_player_left ();
				break;
			}
			break;
		case(MoveRequests.Right):
			switch (current_jump_state) {
			case(JumpStates.LANDED):
				break;

			//Committed jump
			case(JumpStates.JUMPED_ONCE):
				break;
			case(JumpStates.JUMPED_TWICE_OR_MORE):
				break;

			default:
				player_audio.player_walk ();
				switch(player_direction){
				case(PlayerFacingDirection.LEFT):
					armature.transform.localScale = new Vector3 (
						-armature.transform.localScale.x,
						armature.transform.localScale.y,
						armature.transform.localScale.z
					);
					player_direction = PlayerFacingDirection.RIGHT;
					break;
				default:
					break;
				}
				animator.SetBool ("IsRunning", true);
				move_player_right ();
				break;
			}
			break;
		case(MoveRequests.ZeroVelocity):
			animator.SetBool ("IsRunning", false);
			switch (current_jump_state) {
			case(JumpStates.JUMPED_ONCE):
				break;
			case(JumpStates.JUMPED_TWICE_OR_MORE):
				break;
			default:
				zero_player_velocity ();
				break;
			}
			break;
		case(MoveRequests.Punch):
			punch ();
			break;
		default:
			break;
		}

	}

	private void punch(){
		if (!animator.GetBool ("IsRunning")) {
			animator.SetBool ("Jab", true);
		}
		if (animator.GetBool ("IsRunning") && animator.GetBool ("IsJumping")) {
			animator.SetBool ("Jab", true);
		}
		//this boolean will be set to false in the ResetJab animator script.
		//This is a subsitute for where I would usually use a trigger because
		//a trigger makes the punch animation play twice.
	}

	public void reset_jump_state(){
		animator.SetBool ("IsJumping", false);
		animator.SetBool ("IsLanding", true);
		zero_player_velocity ();
		current_jump_state = JumpStates.LANDED;
		Invoke ("set_jump_state_hasnt_jumped", 0.3f);
	}

	private void set_jump_state_hasnt_jumped(){
		animator.SetBool ("IsLanding", false);
		current_jump_state = JumpStates.HAS_NOT_JUMPED;
	}

	private void jump_player(){
		switch (current_jump_state) {
		case(JumpStates.HAS_NOT_JUMPED):
			current_jump_state = JumpStates.JUMPED_ONCE;
			break;
		case(JumpStates.JUMPED_ONCE):
			current_jump_state = JumpStates.JUMPED_TWICE_OR_MORE;
			break;
		default:
			break;
		}
		rb.velocity = new Vector3 (rb.velocity.x * jump_x_amplifier, jump_magnitude, rb.velocity.z);
	}

	private void move_player_left(){
		switch (current_jump_state) {
		case(JumpStates.LANDED):
			break;
		case(JumpStates.HAS_NOT_JUMPED):
			if (Mathf.Abs (rb.velocity.x) <= max_walking_speed) {
				rb.AddForce (new Vector3 (-walking_speed, 0, 0));
			}
			switch (player_direction) {
			case(PlayerFacingDirection.RIGHT):
				//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				//player_direction = PlayerFacingDirection.RIGHT;
				break;
			}
			break;
		case(JumpStates.JUMPED_ONCE):
			if (Mathf.Abs (rb.velocity.x) <= max_walking_speed) {
				rb.AddForce (new Vector3 (-walking_speed, 0, 0));
			}
			switch (player_direction) {
			case(PlayerFacingDirection.RIGHT):
				//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				//player_direction = PlayerFacingDirection.RIGHT;
				break;
			}
			break;
		case(JumpStates.JUMPED_TWICE_OR_MORE):
			if (Mathf.Abs (rb.velocity.x) <= max_walking_speed) {
				rb.AddForce (new Vector3 (-walking_speed, 0, 0));
			}
			switch (player_direction) {
			case(PlayerFacingDirection.RIGHT):
				//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				//player_direction = PlayerFacingDirection.RIGHT;
				break;
			}
			break;
		}
	}

	private void move_player_right(){
		switch (current_jump_state) {
		case(JumpStates.LANDED):
			break;
		case(JumpStates.HAS_NOT_JUMPED):
			if (Mathf.Abs (rb.velocity.x) <= max_walking_speed) {
				rb.AddForce (new Vector3 (walking_speed, 0, 0));
			}
			switch (player_direction) {
			case(PlayerFacingDirection.LEFT):
				//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				//player_direction = PlayerFacingDirection.RIGHT;
				break;
			}
		break;
		case(JumpStates.JUMPED_ONCE):
			if (Mathf.Abs(rb.velocity.x) <= max_walking_speed) {
				rb.AddForce(new Vector3 (walking_speed, 0, 0));
			}
			switch (player_direction) {
				case(PlayerFacingDirection.LEFT):
					//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
					//player_direction = PlayerFacingDirection.RIGHT;
					break;
			}
		break;
		case(JumpStates.JUMPED_TWICE_OR_MORE):
			if (Mathf.Abs(rb.velocity.x) <= max_walking_speed) {
				rb.AddForce(new Vector3 (walking_speed, 0, 0));
			}
			switch (player_direction) {
				case(PlayerFacingDirection.LEFT):
					//this.transform.localScale = new Vector3 (-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
					//player_direction = PlayerFacingDirection.RIGHT;
					break;
			}
		break;
		}
	}

	private void zero_player_velocity(){
		rb.velocity = Vector3.zero;
	}
}
