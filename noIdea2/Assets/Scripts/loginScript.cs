using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loginScript : MonoBehaviour {

    public Button loginBtn;
    public Button RegisterBtn;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void verifyLogin() {
        SceneManager.LoadScene("menuScreen");
    }

    public void register()
    {
        SceneManager.LoadScene("menuScreen");
    }

}
