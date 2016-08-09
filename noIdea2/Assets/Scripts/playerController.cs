using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
	public int population;
    public Text populationCounter;

    GameObject[] islands;

	void Start(){
		updatePopulation ();
        populationCounter = GetComponent<Text>() as Text;
    }

	void Update(){
        populationCounter.text = "Population: "+population.ToString("00");
    }

	public void updatePopulation(){
		islands = GameObject.FindGameObjectsWithTag("Player");
		Debug.Log (islands.Length);
		foreach (GameObject island in islands) {
			population += island.GetComponent<islandController> ().capacity;
		}
        Debug.Log (population);

	}
}