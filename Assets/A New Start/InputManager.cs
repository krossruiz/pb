using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private PlayerAnimationManager pam;
	private PlayerMovementManager pmm;
	public GameObject player;

	// Use this for initialization
	void Start () {
		if (player) {
			add_player (player);
		}
	}

	public void add_player(GameObject new_player){
		if (!player) {
			player = new_player;
		}
		pam = player.GetComponentInChildren<PlayerAnimationManager> ();
		pmm = player.GetComponent<PlayerMovementManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			wasd_listener ();
		}
		arrows_listener ();
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
		/////////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.Return)) {
			
		}
		//////////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {

		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {

		}
		///////////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.RightArrow)) {

		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {

		}
		///////////////////////////////////////////
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			
		}
		////////////////////////////////////////////
	}
}
