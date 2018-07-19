using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour {

	private int player_count = 2;
	public GameObject player_one;
	public GameObject player_two;
	public float gravity_magnitude = 9.8f;

	public static GameObject hello;


	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision (9, 10);
		Physics.IgnoreLayerCollision (11,12);
		Physics.gravity = new Vector3(0, -gravity_magnitude, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int get_player_count () {
		return player_count;
	}

}
