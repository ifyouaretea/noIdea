using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score;
	GameObject retry;
	Text high;
	Text text;
	public int highscore;

	public static ScoreManager Instance;
		
	void Awake(){
		Instance = this;
		text = GameObject.Find("Count Text").GetComponent<Text> ();
		high = GameObject.Find("High Score").GetComponent<Text>();
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if (gameObj.tag == "Retry"){
				retry = gameObj;
				retry.SetActive(false);
			}
		}
		highscore = 0;
	}

	void Start(){
		score = 0;
		high.text = "High Score: " + highscore;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	public void end(){
		retry.SetActive (true);
		if (score > highscore) {
			highscore = score;
		}
		high.text = "High Score: " + highscore;
	}

	public void Retry(){
		retry.SetActive (false);
		Timer.Instance.Retry ();
		Start ();
	}
}
