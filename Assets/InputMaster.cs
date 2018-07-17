using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMaster : MonoBehaviour {

	private int player_count;
	public SceneMaster scene_master;

	private GameObject player_one;
	private GameObject player_two;

	private PlayerMovement player_one_movement;
	private PlayerMovement player_two_movement;

	// Use this for initialization
	void Start () {
		scene_master = this.GetComponent<SceneMaster> ();
		player_count = this.scene_master.get_player_count ();
		player_one = scene_master.player_one;
		player_two = scene_master.player_two;
		player_one_movement = player_one.GetComponent<PlayerMovement> ();
		player_two_movement = player_two.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		lefthand_keyboard_listener ();
		righthand_keyboard_listener ();
	}

	void lefthand_keyboard_listener(){
		if (Input.GetKey (KeyCode.A)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.Left);
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.ZeroVelocity);
		}
		if (Input.GetKey (KeyCode.D)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.Right);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.ZeroVelocity);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.Jump);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			player_one_movement.move_request_handler (PlayerMovement.MoveRequests.Punch);
		}
	}

	void righthand_keyboard_listener(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log ("Left Arrow");
			player_two_movement.move_request_handler (PlayerMovement.MoveRequests.Left);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			player_two_movement.move_request_handler (PlayerMovement.MoveRequests.ZeroVelocity);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log ("Right Arrow");
			player_two_movement.move_request_handler (PlayerMovement.MoveRequests.Right);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			player_two_movement.move_request_handler (PlayerMovement.MoveRequests.ZeroVelocity);
		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			Debug.Log ("Right Shift");
			player_two_movement.move_request_handler (PlayerMovement.MoveRequests.Jump);	
		}
	}
}
