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
		animator.SetBool ("jumping", false);
	}

	public void run(){
		if(!animator.GetBool("running"))
			animator.SetBool ("running", true);
	}

	public void stop_running(){
		if(animator.GetBool("running"))
			animator.SetBool ("running", false);
	}

}
