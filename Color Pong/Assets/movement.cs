using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	private float speed = 40;
	public Color color;
	// Use this for initialization
	void Start () {
	}

	public void setColor(Color eColor) {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = eColor;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		
		speed = speed * -1;
		ScoreController.changeScore ();
	}
}
