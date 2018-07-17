using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumper : MonoBehaviour {

	public enum PlayerBumperType{
		TOP_BUMPER,
		BOTTOM_BUMPER,
		LEFT_BUMPER,
		RIGHT_BUMPER,
		FORWARD_HAND,
		BACK_HAND
	}

	public PlayerBumperType player_bumper_type;
	private PlayerBumperMaster player_bumper_master;
	private PlayerMovement player_movement;

	// Use this for initialization
	void Start () {
		player_bumper_master = this.GetComponentInParent<PlayerBumperMaster> ();
		player_movement = this.GetComponentInParent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		switch(player_bumper_type){
		case(PlayerBumper.PlayerBumperType.BOTTOM_BUMPER):
			player_bumper_master.increment_bumper_intersection_count (player_bumper_type);
			break;
		default:
			break;
		}
	}
	void OnTriggerExit(Collider other){
		switch(player_bumper_type){
		case(PlayerBumper.PlayerBumperType.BOTTOM_BUMPER):
			player_bumper_master.decrement_bumper_intersection_count (player_bumper_type);
			break;
		default:
			break;
		}	
	}

	void OnTriggerStay(Collider other){
		switch (player_movement.current_jump_state) {
		case(PlayerMovement.JumpStates.JUMPED_TWICE_OR_MORE):
			player_movement.current_jump_state = PlayerMovement.JumpStates.HAS_NOT_JUMPED;
			break;
		default:
			break;
		}
	}
}
