﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void test(){
		Debug.Log ("test");
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
}
