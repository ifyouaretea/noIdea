using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loginScript : MonoBehaviour {

    public Button loginBtn;
    public InputField loginField;
    public InputField pwField;
    public Text errorMsg;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void verifyLogin() {
        string url = "http://localhost:8080/noidea/userLogin.php";
        WWWForm form = new WWWForm();
        form.AddField("username", loginField.text);
        form.AddField("userpassword", pwField.text);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));

        //if (loginField.text == "admin"){
        //    if (pwField.text == "pw")
        //    SceneManager.LoadScene("Login Scene");
        //}
        //else
        //{
        //    errorMsg.text = "Account not found. Please register.";
        //}
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

         // check for errors
        if (www.error == null)
        {
            if (www.text == "<?False")
            {
                Debug.Log("Login Error.");
            }
            else
            {

                SceneManager.LoadScene("Login Scene");
            }
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    public void register()
    {
        string url = "http://localhost:8080/noidea/userRegistration.php";
        WWWForm form = new WWWForm();
        form.AddField("username", loginField.text);
        form.AddField("userpassword", pwField.text);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest2(www));

    }

    IEnumerator WaitForRequest2(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log(www.text);
            //if (www.text == "<?False")
            //{
            //    Debug.Log("Login Error.");
            //}
            //else
            //{
            //    SceneManager.LoadScene("Login Scene");
            //}
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

}
