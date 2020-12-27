using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSetting : MonoBehaviour {
	// Use this for initialization
	public LeaderBoardText lbt;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSong() {
		SongSelector.songPath ="Assets/Songs/" + GetComponentInChildren<Text> ().text + ".txt";
		SongSelector.songName = GetComponentInChildren<Text> ().text;
		Debug.Log (SongSelector.songPath);
	}

	public void setLeaderBoard() {
		lbt.displayLeaderBoard(LeaderBoardBehavior.findSongRecord (GetComponentInChildren<Text> ().text));
	}
}
