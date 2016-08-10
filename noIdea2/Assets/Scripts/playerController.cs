using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class playerController : MonoBehaviour {
	public int maxPopulation;
    public Text populationCounter;
	public int shipPopulation;
	public GameObject[] islands;



	void Start(){
		maxPopulation = 30;
		shipPopulation = 0;
    }

	void Update(){
		islands = GameObject.FindGameObjectsWithTag ("Player");
		shipPopulation = 0;
		foreach (GameObject island in islands){
			shipPopulation += island.GetComponent<islandController> ().curr;
		}
        populationCounter.text = shipPopulation.ToString("00")+"/"+maxPopulation.ToString("00");
    }
}