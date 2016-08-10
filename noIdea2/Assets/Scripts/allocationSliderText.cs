using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class allocationSliderText : MonoBehaviour {
    public Text percentText;
    public Slider allocationSlider;

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        percentText.text = (allocationSlider.value * 25).ToString("00") + "%";
	}
}
