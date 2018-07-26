using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColliderStateController : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		PlayerHandCollider[] hand_colliders;
		PlayerHandCollider front_hand = null;

		hand_colliders = animator.gameObject.GetComponentsInChildren<PlayerHandCollider> ();
		Debug.Log (hand_colliders.Length);
		for (int i = 0; i < hand_colliders.Length; i++) {
			if (hand_colliders [i].player_hand_placement == PlayerHandCollider.PlayerHandPlacement.FRONT) {
				front_hand = hand_colliders [i];
			}
		}
		if (stateInfo.IsName ("Enabled")) {
			if(front_hand != null)
				front_hand.set_front_hand_collider (true);
		}
		if (stateInfo.IsName ("Disabled")) {
			if(front_hand != null)
				front_hand.set_front_hand_collider (false);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
