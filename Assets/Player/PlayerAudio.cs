using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	public string player_walk_ref;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void player_walk(){
		FMODUnity.RuntimeManager.PlayOneShot (player_walk_ref, this.transform.position);
	}
}
