using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

	public Transform player_left_foot;
	public Transform player_right_foot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void play_left_step(){
		FMODUnity.RuntimeManager.PlayOneShot ("event:/Step", player_left_foot.position);
	}

	void play_right_step(){
		FMODUnity.RuntimeManager.PlayOneShot ("event:/Step", player_right_foot.position);
	}
}
