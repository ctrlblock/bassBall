using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Specialized;

public class blockManager : MonoBehaviour {
	//the OrderedDictionary enumerator is not treating me kindly, so for now I am just implementing 2 lists
	private List<int> songTimes = new List<int>();
	private List<int> songNotes = new List<int>();
	int timer = 0;
	private int songProgress = 0;
	public int numberBlocks = 3;
	bool random = false;
	public List<fireBall> blocks = new List<fireBall>();
	public GameObject noteObject;
	public bool triggered = false;
	public ScoreController sc;
	// Use this for initialization
	void Start () {
		readSong ();
		Debug.Log ("done");
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Block") {
				blocks.Add (child.gameObject.GetComponent<fireBall>());
				print ("This child is a block");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((int)(Time.time*2)-3 > timer) {
			timer++;
			if (!triggered) {
				//initiate note here
				//GameObject noteBlock = Instantiate(noteObject, blocks[0].transform.position);
				if (random) {
					randomUpdate (timer);
				} else {
					songUpdate (timer);
				}
			}
		} else { 
			triggered = false;
		}
	}

	void songUpdate(int time) {
		Debug.Log (time);
		if(songTimes[songProgress] == time) {
				blocks [songNotes [songProgress]].fire ();
				triggered = true;
				songProgress++;
		}
	}

	void randomUpdate(int time) {
		blocks [GenerateNextNote()].fire ();
			triggered = true;
			songProgress++;
	}

	int GenerateNextNote() {
		int note = ((int)(Random.value * 3)) % 3;
		//Debug.Log (note);
		return note;
	}

	void readSong() {
		if (SongSelector.songPath.Equals( "random")) {
			random = true;
		} else {
			Debug.Log ("Song Selected");
			StreamReader reader = new StreamReader (SongSelector.songPath); 
			string[] arr = reader.ReadToEnd().Split (',');
			reader.Close();
			for (int i = 0; i < arr.Length; i += 2) {
				songTimes.Add (int.Parse(arr [i])); 
				songNotes.Add(int.Parse(arr [i + 1]));
			}
		}
	}
}
