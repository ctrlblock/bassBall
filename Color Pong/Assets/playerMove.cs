using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	private float speed = 150f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Vertical")*Time.deltaTime*speed;
		transform.Translate (0, move, 0);
		//Debug.Log (transform.position);
	}
}
