using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class playerController : MonoBehaviour {
	public int maxPopulation;
    public Text populationCounter;
	public int shipPopulation;
	public List<GameObject> ships;

    GameObject[] islands;


	void Start(){
    }

	void Update(){
        //updatePopulation ();
        shipPopulation = ships.Count;
        populationCounter.text = shipPopulation.ToString("00")+"/"+maxPopulation.ToString("00");
    }
}