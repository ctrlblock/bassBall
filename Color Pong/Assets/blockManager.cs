using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockManager : MonoBehaviour {
	public int numberBlocks = 3;
	public List<fireBall> blocks = new List<fireBall>();
	public bool triggered = false;
	public ScoreController sc;
	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Block") {
				blocks.Add (child.gameObject.GetComponent<fireBall>());
				print ("This child is a block");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (((int)(Time.time * 10)) % 6 == 0) {
			if (!triggered) {
				blocks [GenerateNextNote ()].fire ();
				triggered = true;
			}
		} else {
			triggered = false;
		}
	}

	int GenerateNextNote() {
		int note = ((int)(Random.value * 3)) % 3;
		//Debug.Log (note);
		return note;
	}
}
