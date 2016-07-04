using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer;
	Text text;
	Button butt;

	public static Timer Instance;
	void Awake () {
		Instance = this;
		text = GetComponent<Text> ();
	}

	void Start(){
		timer = 10.0f;
		butt = GameObject.Find ("Button").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		text.text = "Time Left: " + timer.ToString("0");
		if (timer <= 0) {
			timer = 0;
			text.text = "Score: " + ScoreManager.Instance.score;
			ScoreManager.Instance.end ();

			butt.interactable=false;
		}
	}

	public void Retry(){
		Start ();
		butt.interactable=true;
	}
}
