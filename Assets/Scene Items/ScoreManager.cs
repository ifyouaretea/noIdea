﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text text;
	void Awake(){
		text = GetComponent<Text> ();
		score = 0;
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}
}
