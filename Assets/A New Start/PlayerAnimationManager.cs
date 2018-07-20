using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void trigger_jab(){
		animator.SetBool (PlayerAnimatorParameters.jab_bool_id, true);
	}

	public void trigger_death(){
		animator.SetTrigger (PlayerAnimatorParameters.death_trigger_id);
	}

	public void trigger_revive(){
		animator.SetTrigger (PlayerAnimatorParameters.revive_trigger_id);
	}

	public void trigger_jump(){
		animator.SetTrigger (PlayerAnimatorParameters.jumping_bool_id);
	}

	public void trigger_landing(){
		animator.SetBool (PlayerAnimatorParameters.jumping_bool_id, false);
	}

	private void run(){
		if(!animator.GetBool(PlayerAnimatorParameters.running_bool))
			animator.SetBool (PlayerAnimatorParameters.running_bool, true);
	}

	public void run_left(){
		run ();
		face_left ();
	}

	public void run_right(){
		run ();
		face_right ();
	}

	public void stop_running(){
		if(animator.GetBool(PlayerAnimatorParameters.running_bool))
			animator.SetBool (PlayerAnimatorParameters.running_bool, false);
	}

	public void face_left(){
		animator.SetBool (PlayerAnimatorParameters.is_facing_right, false);
		animator.SetBool (PlayerAnimatorParameters.is_facing_left, true);
	}

	public void face_right(){
		animator.SetBool (PlayerAnimatorParameters.is_facing_left, false);
		animator.SetBool (PlayerAnimatorParameters.is_facing_right, true);
	}

}
