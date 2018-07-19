using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumperMaster : MonoBehaviour {
	public int bottom_bumper_collider_intersection_count { get; private set;} = 0;
	public int top_bumper_collider_intersection_count { get; private set;} = 0;
	public int left_bumper_collider_intersection_count { get; private set;} = 0;
	public int right_bumper_collider_intersection_count { get; private set;} = 0;

	private PlayerMovement player_movement;
	private Animator animator;
	private OtherPlayerInfo other_player_info;

	private PlayerMaster player_master;

	// Use this for initialization
	void Start () {
		player_master = this.GetComponent<PlayerMaster> ();
		player_movement = player_master.player_movement;
		animator = player_master.animator;
		other_player_info = player_master.other_player_info;
	}


	// Update is called once per frame
	void Update () {
		
	}

	public void left_bumper_hit(Collider collider){
		Debug.Log ("L_BUMP");
		try{
			PlayerBumper.PlayerBumperType player_bumper_type = collider.GetComponent<PlayerBumper> ().player_bumper_type;
			Debug.Log(player_bumper_type);

			if (player_bumper_type != null) {
				Debug.Log("Not null");
				switch(player_bumper_type){

				case(PlayerBumper.PlayerBumperType.FORWARD_HAND):
					//
					//I don't want THIS player's animator jab, I want the OTHER player's!
					//How to reference?
					//
					Debug.Log("Die?");
					player_master.animator.SetBool("IsDead", true);					break;
				default:
					break;
				}
			}
		}catch(System.NullReferenceException e){

		}
	}

	public void right_bumper_hit(Collider collider){
		Debug.Log ("R_BUMP");
		try{
			PlayerBumper.PlayerBumperType player_bumper_type = collider.GetComponent<PlayerBumper> ().player_bumper_type;
			Debug.Log(player_bumper_type);

			if (player_bumper_type != null) {
				Debug.Log("Not null");
				switch(player_bumper_type){
				case(PlayerBumper.PlayerBumperType.FORWARD_HAND):
					//
					//I don't want THIS player's animator jab, I want the OTHER player's!
					//How to reference?
					//
					Debug.Log("Die?");
					player_master.animator.SetBool("IsDead", true);
					break;
				default:
					break;
				}
			}
		}catch(System.NullReferenceException e){
			
		}
	}
		

	public void front_bumper_collision(){
		Debug.Log ("Hit!");
	}

	public void increment_bumper_intersection_count(PlayerBumper.PlayerBumperType bumper_type){
		switch (bumper_type) {
		case(PlayerBumper.PlayerBumperType.BOTTOM_BUMPER):
			switch (bottom_bumper_collider_intersection_count) {
			case(0):
				this.GetComponent<PlayerMovement>().reset_jump_state ();
				break;
			default:
				break;
			}
			bottom_bumper_collider_intersection_count += 1;
			break;
		case(PlayerBumper.PlayerBumperType.LEFT_BUMPER):
			left_bumper_collider_intersection_count += 1;
			break;
		case(PlayerBumper.PlayerBumperType.RIGHT_BUMPER):
			right_bumper_collider_intersection_count += 1;
			break;
		case(PlayerBumper.PlayerBumperType.TOP_BUMPER):
			top_bumper_collider_intersection_count += 1;
			break;
		default:
			break;
		}
		Debug.Log (bumper_type.ToString() + bottom_bumper_collider_intersection_count.ToString());
	}

	public void decrement_bumper_intersection_count(PlayerBumper.PlayerBumperType bumper_type){
		switch (bumper_type) {
		case(PlayerBumper.PlayerBumperType.BOTTOM_BUMPER):
			bottom_bumper_collider_intersection_count -= 1;
			break;
		case(PlayerBumper.PlayerBumperType.LEFT_BUMPER):
			left_bumper_collider_intersection_count -= 1;
			break;
		case(PlayerBumper.PlayerBumperType.RIGHT_BUMPER):
			right_bumper_collider_intersection_count -= 1;
			break;
		case(PlayerBumper.PlayerBumperType.TOP_BUMPER):
			top_bumper_collider_intersection_count -= 1;
			break;
		default:
			break;
		}
		Debug.Log (bumper_type.ToString() + bottom_bumper_collider_intersection_count.ToString());
	}

	private void zero_collider_intersections(PlayerBumper.PlayerBumperType bumper_type){
		switch (bumper_type) {
		case(PlayerBumper.PlayerBumperType.BOTTOM_BUMPER):;
			break;
		default:
			break;
		}
	}
}
