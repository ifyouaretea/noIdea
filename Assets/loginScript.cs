using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loginScript : MonoBehaviour {

    public Button loginBtn;
    public InputField loginField;
    public InputField pwField;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void verifyLogin() {
        if (loginField.text == "admin"){
            if (pwField.text == "pw")
            SceneManager.LoadScene("Login Scene");
        }
    }

}
