using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer;
	Text text;

	public static Timer Instance;
	void Awake () {
		Instance = this;
		text = GetComponent<Text> ();
	}

	void Start(){
		timer = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		text.text = "Time Left: " + timer.ToString("0");
		if (timer <= 0) {
			timer = 0;
			ScoreManager.Instance.end ();
			text.text = "Score: " + ScoreManager.Instance.score;
		}
	}

	public void Retry(){
		Start ();
	}
}
