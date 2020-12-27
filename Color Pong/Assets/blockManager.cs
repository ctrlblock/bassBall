﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class blockManager : MonoBehaviour {
	//the OrderedDictionary enumerator is not treating me kindly, so for now I am just implementing 2 lists
	private List<int> songTimes = new List<int>();
	private List<string> songNotes = new List<string>();
	int timer = 0;
	int totalNotes = 200;
	private int songProgress = 0;
	public int numberBlocks = 3;
	bool random = false;
	public List<fireBall> blocks = new List<fireBall>();
	public GameObject noteObject;
	public bool triggered = false;
	public ScoreController sc;
	float startTime = 0;
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
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreController.total >= totalNotes) {
			endGame ();
		}
		if ((int)((Time.time-startTime)*2)-3 > timer) {
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

	void endGame() {
		LeaderBoardBehavior.updateSongRecord (SongSelector.songName, ScoreController.score);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}

	void songUpdate(int time) {
		if (songTimes.Count > songProgress) {
			if (songTimes [songProgress] == time) {
				for (int i = 0; i < songNotes [songProgress].Length; i++) {
					int songNote = int.Parse (songNotes [songProgress] [i].ToString ());
					blocks [songNote].fire (songNotes [songProgress]);
				}
				triggered = true;
				songProgress++;
			}
		}
	}

	void randomUpdate(int time) {
		string note = GenerateNextNote ();
		for (int i = 0; i < note.Length; i++) {
			blocks [int.Parse(note[i].ToString())].fire (note);
		}
			triggered = true;
			songProgress++;
	}

	string GenerateNextNote() {
		int note = ((int)(Random.value * 3)) % 3;
		string noteString = note.ToString ();
		if (note < 2) {
			int secondNote = ((int)(Random.value * 2)) % 2;
			if (secondNote == 1)
				noteString += (note + 1).ToString ();
		}
		return noteString;
	}

	void readSong() {
		if (SongSelector.songPath.Equals( "random")) {
			random = true;
		} else {
			totalNotes = 0;
			Debug.Log ("Song Selected");
			StreamReader reader = new StreamReader (SongSelector.songPath); 
			string[] arr = reader.ReadToEnd().Split (',');
			reader.Close();
			for (int i = 0; i < arr.Length; i += 2 ) {
				songTimes.Add (int.Parse(arr [i])); 
				songNotes.Add(arr [i+1]);
				totalNotes += arr [i+1].Length;
			}
		}
		Debug.Log ("Total Notes: " + totalNotes);
	}
		
}
