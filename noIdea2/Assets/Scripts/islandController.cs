using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;


public class islandController : MonoBehaviour
{

	public GameObject ship;
	public GameObject island;
	public Vector3 spawnValues;
	public Canvas canvas;

	public string owner;//'player', 'ai', 'neutral'
	public char size;
	public int capacity;
	public bool generate;
	int maxpop;
	public List<GameObject> ships;
	void Start ()
	{
		setCapacity ();
		if (gameObject.tag == "Player")
			playerCapture ();
		if (gameObject.tag == "AI")
			aiCapture ();
		if (gameObject.tag == "Neutral")
			setNeutral ();
		Debug.Log (gameObject.tag);
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		
	}

	IEnumerator SpawnWaves (){
		while (generate) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;            
			GameObject shippu = Instantiate (ship) as GameObject;
			shippu.transform.SetParent (canvas.transform);
			shippu.transform.localPosition = spawnPosition;
			shippu.transform.localRotation = spawnRotation;
			if (gameObject.tag == "Player")
				shippu.GetComponent<Image> ().color = Color.green;
			if (gameObject.tag == "AI")
				shippu.GetComponent<Image> ().color = Color.red;
			shippu.GetComponent<shipController>().rotateAbout = gameObject.GetComponent<Button>().transform.position;
			ships.Add (shippu);
			if (ships.Count > maxpop) {
				generate = false;
			}
			yield return new WaitForSeconds (1);
		}
	}

	void playerCapture ()
	{
		this.owner = "player";
		gameObject.tag = "Player";
		gameObject.GetComponent<Image> ().color = Color.green;
		generate = true;
		ships = canvas.GetComponent<playerController> ().ships;
		canvas.GetComponent<playerController> ().maxPopulation += capacity;
		maxpop = canvas.GetComponent<playerController> ().maxPopulation;
	}

	void aiCapture ()
	{
		this.owner = "ai";
		gameObject.tag = "AI";
		gameObject.GetComponent<Image> ().color = Color.red;
		generate = true;
		ships = canvas.GetComponent<aiController> ().ships;
		canvas.GetComponent<aiController> ().maxPopulation += capacity;
		maxpop = canvas.GetComponent<aiController> ().maxPopulation;
	}

	void setNeutral ()
	{
		this.owner = "neutral";
		gameObject.tag = "Neutral";
		gameObject.GetComponent<Image> ().color = Color.grey;
		generate = false;
	}

	void setCapacity ()
	{
		if (this.size == 's')
			this.capacity = 10;
		else if (this.size == 'm')
			this.capacity = 15;
		else if (this.size == 'l')
			this.capacity = 20;
	}
}
