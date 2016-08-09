using UnityEngine;
using System.Collections;


public class playerController : MonoBehaviour {
	public int population;
	GameObject[] islands;

	void Start(){
		updatePopulation ();
	}

	void Update(){
		
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