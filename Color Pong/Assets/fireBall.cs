using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {
	public GameObject ball;
	public Color color = Color.red;
	public string colorString;
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = color;
	}

	public void fire(string songNotes) {
		ball = Instantiate (ball);
		ball.transform.position = transform.position;
		ballBehavior ballScript = ball.GetComponent<ballBehavior> ();
		ballScript.setColor (color, songNotes);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
