using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour {
    public GameObject timer;
    public GameObject score;

	// Use this for initialization
	void Start () {
        //timer = GameObject.Find("Timer");
        //int secs = timer.GetComponent<timerScript>().


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
        //slider.GetComponent<allocationSliderText>().allocationSlider.value;

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level2");
    }
}
