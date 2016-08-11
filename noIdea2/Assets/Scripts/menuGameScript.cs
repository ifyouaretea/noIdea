using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuGameScript : MonoBehaviour {
    
	void Start () {
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
