using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {
	public GameObject ball;
	public Color color = Color.red;
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = color;
	}

	public void fire() {
		ball = Instantiate (ball);
		ball.transform.position = transform.position;
		movement ballScript = ball.GetComponent<movement> ();
		ballScript.setColor (color);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
