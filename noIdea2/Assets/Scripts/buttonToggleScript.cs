using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class buttonToggleScript : MonoBehaviour {

    public Sprite resumeIcon;
    public bool condition;

    private Button button;


	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        condition = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (condition)
        {
            button.image.overrideSprite = resumeIcon;
        }else
        {
            button.image.overrideSprite = null;
        }
    }

    public void buttonStateToggle()
    {
        if (condition == true)
        {
            condition = false;
        }else
        {
            condition = true;
        }
    }
}
