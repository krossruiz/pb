using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesIndicator : MonoBehaviour {

	private Image indicator_image;
	public Sprite activated_sprite;
	public Sprite deactivated_sprite;

	// Use this for initialization
	void Start () {
		indicator_image = this.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void deactivate(){
		indicator_image.sprite = deactivated_sprite;
		Debug.Log ("Deactivated indicator");
	}

	public void activate(){
		indicator_image.sprite = activated_sprite;
		Debug.Log ("Activated indicator");
	}
}
