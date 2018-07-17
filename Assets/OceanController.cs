using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanController : MonoBehaviour {

	private SkinnedMeshRenderer skinned_mesh_renderer;

	// Use this for initialization
	void Start () {
		skinned_mesh_renderer = this.GetComponent<SkinnedMeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		skinned_mesh_renderer.SetBlendShapeWeight (0, (50f * (Mathf.Sin (Time.fixedTime)) + 50));
		skinned_mesh_renderer.SetBlendShapeWeight (1, (50f * (Mathf.Cos (Time.fixedTime)) + 50));		
	}
}
