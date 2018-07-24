using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandCollider : MonoBehaviour {

	public enum PlayerHandPlacement{ FRONT, BACK }
	public PlayerHandPlacement player_hand_placement;
	private Animator animator;
	private PlayerAnimationManager pam;

	// Use this for initialization
	void Start () {
		animator = this.transform.parent.parent.GetComponent<Animator> ();
		pam = animator.GetComponent<PlayerAnimationManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		Debug.Log (player_hand_placement.ToString () + " collided");
	}

	public void set_hand_collider(bool val){
		if (val)
			Debug.Log ("HAND COLLIDER ENABLED");
		else
			Debug.Log ("HAND COLLIDER DISABLED");
		this.GetComponent<Collider> ().enabled = val;
	}
		
}
