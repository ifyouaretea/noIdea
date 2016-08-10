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
        counterText.text = seconds.ToString("00");
	}

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

    public void togglePauseResume()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
