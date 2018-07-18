using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

	public Animator animator;
	public OtherPlayerInfo other_player_info;
	public PlayerMovement player_movement;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator> ();
		other_player_info = this.GetComponent<OtherPlayerInfo> ();
		player_movement = this.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
