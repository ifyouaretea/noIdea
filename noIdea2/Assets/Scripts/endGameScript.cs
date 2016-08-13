using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour {
    public GameObject canvas;

    // Use this for initialization
    void Start () {

    }

    void Update () {
        if (canvas.GetComponent<playerController> ().maxPopulation == canvas.GetComponent<playerController> ().shipPopulation)
        {
            SceneManager.LoadScene("winScreen");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void menuGame()
    {
        SceneManager.LoadScene("menuScreen");
    }
}
