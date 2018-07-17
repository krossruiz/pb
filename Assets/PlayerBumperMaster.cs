using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumperMaster : MonoBehaviour {
	public int bottom_bumper_collider_intersection_count { get; private set;} = 0;
	public int top_bumper_collider_intersection_count { get; private set;} = 0;
	public int left_bumper_collider_intersection_count { get; private set;} = 0;
	public int right_bumper_collider_intersection_count { get; private set;} = 0;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

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
