using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

	private int left_player_lives = 5;
	private int right_player_lives = 5;

	public PlayerLivesIndicator[] left_player_lives_indicators;
	public PlayerLivesIndicator[] right_player_lives_indicators;

	public TextMeshProUGUI game_over_text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decrement_left_player_lives(){
		if (left_player_lives > 1) {
			left_player_lives -= 1;
			left_player_lives_indicators [left_player_lives].deactivate();
		} else if (left_player_lives == 1) {
			left_player_lives -= 1;
			left_player_lives_indicators [left_player_lives].deactivate();
			game_over_text.SetText ("RIGHT PLAYER WINS");
		}
	}

	public void decrement_right_player_lives(){
		if (right_player_lives > 1) {
			right_player_lives -= 1;
			right_player_lives_indicators [right_player_lives].deactivate();
		} else if (right_player_lives == 1) {
			right_player_lives -= 1;
			right_player_lives_indicators [right_player_lives].deactivate();
			game_over_text.SetText ("LEFT PLAYER WINS");
		}
	}

	public void reset_score(){
		for (int i = 0; i < right_player_lives_indicators.Length; i++) {
			right_player_lives_indicators [i].activate ();
			right_player_lives = 5;
		}
		for (int i = 0; i < left_player_lives_indicators.Length; i++) {
			left_player_lives_indicators [i].activate ();
			left_player_lives = 5;
		}
		game_over_text.SetText ("");
	}
}
