using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject boxer;
	public GameObject master_control;
	private InputManager input_manager;

	// Use this for initialization
	void Start () {
		input_manager = master_control.GetComponent<InputManager> ();
		spawn_boxer ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawn_boxer(){
		GameObject player = Instantiate (boxer.gameObject, this.transform.position, Quaternion.identity);
		input_manager.add_player_one (player);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawCube (this.transform.position, 0.5f * Vector3.one);
	}
}
