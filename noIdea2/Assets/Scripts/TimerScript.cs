using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Text counterText;

    public float timePerRound, seconds;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;	

	}
	
	// Update is called once per frame
	void Update () {
        seconds = (int)((timePerRound)-(Time.time % 60f));
        if (seconds == 0)
        {
            Time.timeScale = 0;
        }
        counterText.text = "Time Left: "+seconds.ToString("00");
	}
}
