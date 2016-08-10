using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
