using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public GameObject player_one;
	public GameObject player_two;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void reset_scene(){
		player_one.GetComponent<PlayerMovementManager> ().request_reset_position ();
		player_two.GetComponent<PlayerMovementManager> ().request_reset_position ();
		player_one.GetComponent<PlayerMovementManager> ().request_revive ();
		player_two.GetComponent<PlayerMovementManager> ().request_revive ();
	}
}
