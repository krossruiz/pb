using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private PlayerAnimationManager pam;
	private PlayerMovementManager pmm;
	private PlayerAnimationManager p2am;
	private PlayerMovementManager p2mm;
	public GameObject player_1;
	public GameObject player_2;

	// Use this for initialization
	void Start () {
		if (player_1) {
			add_player_one (player_1);
		}
		if (player_2) {
			add_player_two (player_2);
		}
	}

	public void add_player_one(GameObject new_player){
		if (!player_1) {
			player_1 = new_player;
		}
		pam = player_1.GetComponentInChildren<PlayerAnimationManager> ();
		pmm = player_1.GetComponent<PlayerMovementManager> ();
	}

	public void add_player_two(GameObject new_player){
		if (!player_2) {
			player_2 = new_player;
		}
		p2am = player_2.GetComponentInChildren<PlayerAnimationManager> ();
		p2mm = player_2.GetComponent<PlayerMovementManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (player_1) {
		//	wasd_listener ();
		//	arrows_listener();
		//}
		//arrows_listener ();
		dualshock_1_listener();
		dualshock_2_listener ();
	}

	void dualshock_1_listener(){
		string joystick_1 = "joystick 1 ";
		if (Input.GetKeyDown (KeyCode.Tab)) {
			pmm.request_revive ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			pmm.request_death ();
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			pmm.request_landing ();
		}
		////////////////////////////////////
		if (Input.GetKey(joystick_1 + "button 0")) {
			pmm.request_jab ();
		}

		float x_axis = Input.GetAxis ("HorizontalP1");
		////////////////////////////////////
		if (x_axis < -0.5) {
			pmm.request_run_left();
		}
			//pmm.request_run_left();
		if (x_axis > -0.5 && x_axis < 0.5) {
			pmm.request_stop_running ();
		}
		/////////////////////////////////////
		if (x_axis > 0.5) {
			pmm.request_run_right ();
		}
		///////////////////////////////////////

		if (Input.GetKeyDown(joystick_1 + "button 1")) {
			pmm.request_jump ();
		}
		///////////////////////////////////////
	}

	void dualshock_2_listener(){
		string joystick_2 = "joystick 2 ";
		if (Input.GetKeyDown (KeyCode.Tab)) {
			p2mm.request_revive ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			p2mm.request_death ();
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			p2mm.request_landing ();
		}
		////////////////////////////////////
		if (Input.GetKey(joystick_2 + "button 0")) {
			p2mm.request_jab ();
		}

		float x_axis = Input.GetAxis ("HorizontalP2");
		////////////////////////////////////
		if (x_axis < 0) {
			p2mm.request_run_left();
		}
		//pmm.request_run_left();
		if (x_axis == 0) {
			p2mm.request_stop_running ();
		}
		/////////////////////////////////////
		if (x_axis > 0) {
			p2mm.request_run_right ();
		}
		///////////////////////////////////////

		if (Input.GetKeyDown(joystick_2 + "button 1")) {
			p2mm.request_jump ();
		}
		///////////////////////////////////////
	}

	void wasd_listener(){
		if (Input.GetKeyDown (KeyCode.Tab)) {
			pmm.request_revive ();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			pmm.request_death ();
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			pmm.request_landing ();
		}
		////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.E)) {
			pmm.request_jab ();
		}
		////////////////////////////////////
		if (Input.GetKey (KeyCode.A)) {
			if (!Input.GetKey (KeyCode.D)) {
				pmm.request_run_left();
			}
			//pmm.request_run_left();
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			if (!Input.GetKey (KeyCode.D)) {
				pmm.request_stop_running ();
			}
		}
		/////////////////////////////////////
		if (Input.GetKey (KeyCode.D)) {
			if(!Input.GetKey(KeyCode.A)){
				pmm.request_run_right ();
			}
			//pmm.request_run_right();
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			if (!Input.GetKey (KeyCode.A)) {
				pmm.request_stop_running ();
			}
		}
		//////////////////////////////////////
		if(Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.A)){
			Debug.Log ("Request face right");
			pmm.request_face_right ();
			pam.stop_running ();
		}
		if (Input.GetKeyDown (KeyCode.A) && Input.GetKey(KeyCode.D)) {
			Debug.Log ("Request face left");
			pmm.request_face_left ();
			pam.stop_running ();
		}
		///////////////////////////////////////

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			pmm.request_jump ();
		}
		///////////////////////////////////////
	}

	void arrows_listener(){
		if (Input.GetKeyDown (KeyCode.RightBracket)) {
			p2mm.request_revive ();
		}
		if (Input.GetKeyDown (KeyCode.Backslash)) {
			p2mm.request_death ();
		}
		//if (Input.GetKeyDown (KeyCode.Z)) {
			//pmm.request_landing ();
		//}
		////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.Return)) {
			p2mm.request_jab ();
		}
		////////////////////////////////////
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (!Input.GetKey (KeyCode.RightArrow)) {
				p2mm.request_run_left();
			}
			//pmm.request_run_left();
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if (!Input.GetKey (KeyCode.RightArrow)) {
				p2mm.request_stop_running ();
			}
		}
		/////////////////////////////////////
		if (Input.GetKey (KeyCode.RightArrow)) {
			if(!Input.GetKey(KeyCode.LeftArrow)){
				p2mm.request_run_right ();
			}
			//pmm.request_run_right();
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if (!Input.GetKey (KeyCode.LeftArrow)) {
				p2mm.request_stop_running ();
			}
		}
		//////////////////////////////////////
		if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)){
			Debug.Log ("Request face right");
			p2mm.request_face_right ();
			p2am.stop_running ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
			Debug.Log ("Request face left");
			p2mm.request_face_left ();
			p2am.stop_running ();
		}
		///////////////////////////////////////

		if (Input.GetKeyDown (KeyCode.RightShift)) {
			p2mm.request_jump ();
		}
		///////////////////////////////////////
	}
}
