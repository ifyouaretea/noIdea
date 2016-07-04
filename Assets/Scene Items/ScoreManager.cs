using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score;
	GameObject retry;
	Text text;

	public static ScoreManager Instance;
		
	void Awake(){
		Instance = this;
		text = GetComponent<Text> ();
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if (gameObj.tag == "Retry"){
				retry = gameObj;
				retry.SetActive(false);
			}
		}
	}

	void Start(){
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	public void end(){
		retry.SetActive (true);

	}

	public void Retry(){
		retry.SetActive (false);
		Timer.Instance.Retry ();
		Start ();
	}
}
