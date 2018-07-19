using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnimatorStates {

	public const int default_anim_layer_index = 0;

	//Registry of all default layer animation state ids
	public const string idle_state_id = "Armature|idle";
	public const string running_state_id = "Armature|running";
	public const string jab_state_id = "Armature|jab";
	public const string jump_state_id = "Armature|jump";
	public const string jump_punch_state_id = "Armature|jump_punch";
	public const string landing_state_id = "Armature|landing";
	public const string death_state_id = "Armature|death";

}
