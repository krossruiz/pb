using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorParameter : StateMachineBehaviour {

	public bool reset_on_enter = false;
	public bool reset_on_exit = false;
	public string parameter = "";

	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (reset_on_enter) {
			switch (parameter) {
			case("jab_qued"):
				animator.SetBool ("jab_qued", false);
				break;
			case("running"):
				animator.SetBool (PlayerAnimatorParameters.running_bool, false);
				break;
			case("revive"):
				animator.SetBool (PlayerAnimatorParameters.revive_bool, false);
				break;
			case("front_hand_collider_enabled"):
				animator.SetBool ("front_hand_collider_enabled", false);
				break;
			default:
				break;
			}
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(reset_on_exit){
			switch (parameter) {
			case(PlayerAnimatorParameters.running_bool):
				animator.SetBool (PlayerAnimatorParameters.running_bool, false);
				break;
			case("jab_qued"):
				animator.SetBool ("jab_qued", false);
				break;
			}
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
