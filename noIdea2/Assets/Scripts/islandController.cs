using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;


public class islandController : MonoBehaviour
{

	public GameObject ship;
	public GameObject island;
	//public Vector3 spawnValues;
	public GameObject canvas;

	int addy;
	public int curr;
	Text current;
	//public int y;
	//public int z;

	public string owner;//'player', 'ai', 'neutral'
	public char size;
	public int capacity;
	public bool generate;
	int maxpop;
	public List<GameObject> ships;
	public List<GameObject> localShips;
	void Start ()
	{
		localShips = new List<GameObject> ();
		canvas = GameObject.Find ("Canvas");
		setCapacity ();
		if (gameObject.tag == "Player")
			playerCapture (capacity/2);
		if (gameObject.tag == "AI")
			aiCapture ();
		if (gameObject.tag == "Neutral")
			setNeutral ();
		Debug.Log (gameObject.tag);
		current = gameObject.GetComponentInChildren<Text> ();
		current.text = curr.ToString("00");
		//StartCoroutine (SpawnWaves ());
	}

	void Update(){
		current.text = curr.ToString("00");
	}

	IEnumerator SpawnWaves (){
		while (generate) {
            if (curr == 1)
                curr += 1;
            else
                curr += curr / 4;

			Vector3 islandLoc = gameObject.transform.localPosition;
			Vector3 spawnPosition = new Vector3 (islandLoc.x, islandLoc.y+addy,islandLoc.z);
			Quaternion spawnRotation = Quaternion.identity;            
			GameObject shippu = Instantiate (ship) as GameObject;
			shippu.transform.SetParent (canvas.transform);
			shippu.transform.localPosition = spawnPosition;
			shippu.transform.localRotation = spawnRotation;
			if (gameObject.tag == "Player")
				shippu.GetComponent<Image> ().color = Color.green;
			if (gameObject.tag == "AI")
				shippu.GetComponent<Image> ().color = Color.red;
			shippu.GetComponent<shipController>().island = gameObject.GetComponent<Button>();
			ships.Add (shippu);
			localShips.Add (shippu);
			if (localShips.Count >= capacity || curr >= capacity) {
				generate = false;
			}
			yield return new WaitForSeconds (1);
		}
	}

	public void playerCapture (int start)
	{
		curr = start;
		this.owner = "player";
		gameObject.tag = "Player";
		gameObject.GetComponent<Image> ().color = Color.green;
		generate = true;
        ships = canvas.GetComponent<playerController> ().ships;
		canvas.GetComponent<playerController> ().maxPopulation += capacity;
		maxpop = canvas.GetComponent<playerController> ().maxPopulation;
        this.StartCoroutine(SpawnWaves());
    }

    public void playerMove(int start)
    {
        curr -= start;
        generate = true;
        this.StartCoroutine(SpawnWaves());
    }

    public void aiCapture ()
	{
		this.owner = "ai";
		gameObject.tag = "AI";
		gameObject.GetComponent<Image> ().color = Color.red;
		generate = true;
		ships = canvas.GetComponent<aiController> ().ships;
		canvas.GetComponent<aiController> ().maxPopulation += capacity;
		maxpop = canvas.GetComponent<aiController> ().maxPopulation;
        this.StartCoroutine(SpawnWaves());
    }

	public void setNeutral ()
	{
		this.owner = "neutral";
		gameObject.tag = "Neutral";
		gameObject.GetComponent<Image> ().color = Color.grey;
		generate = false;
	}

	public void setCapacity ()
	{
		if (this.size == 's') {
			this.capacity = 10;
			addy = 25;
		} else if (this.size == 'm') {
			this.capacity = 15;
			addy = 40;
		} else if (this.size == 'l') {
			this.capacity = 20;
			addy = 60;
		}
	}
}
