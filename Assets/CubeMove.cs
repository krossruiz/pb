using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(Mathf.Cos(Time.fixedTime) * Time.deltaTime, Mathf.Sin(Time.fixedTime) * Time.deltaTime, 0));
	}
}
