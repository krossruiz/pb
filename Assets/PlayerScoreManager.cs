using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour {

	public ScoreManager score_manager;
	private PlayerManager player_manager;

	// Use this for initialization
	void Start () {
		player_manager = this.GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decrement_score(){
		if (player_manager.player_number == 1) {
			score_manager.decrement_left_player_lives ();
		}
		if (player_manager.player_number == 2) {
			score_manager.decrement_right_player_lives ();
		}
	}
}
