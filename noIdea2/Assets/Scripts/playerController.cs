using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
	public int maxPopulation;
    public Text populationCounter;
	public int shipPopulation;
	public GameObject[] islands;



	void Start(){
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        if (sceneName == "Level1")
        {
            maxPopulation = 30;
        }else if (sceneName == "Level 2")
        {
            maxPopulation = 160;
        }
        
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