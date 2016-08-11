using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;


public class islandController : MonoBehaviour
{

	public GameObject ship;
	public GameObject island;
	public GameObject canvas;

	int addy;
	public int curr;
	Text current;

	public string owner;//'player', 'ai', 'neutral'
	public char size;
	public int capacity;
	public bool generate;
	int maxpop;

	public List<GameObject> localShips;
	void Start ()
	{
		localShips = new List<GameObject> ();
		canvas = GameObject.Find ("Canvas");
		setCapacity ();
        if (gameObject.tag == "AI")
            aiCapture();
        else if (gameObject.tag == "Player") {
            playerCapture(capacity / 2);
            current = gameObject.GetComponentInChildren<Text>();
            current.text = curr.ToString("00");
        }
        else if (gameObject.tag == "Neutral")
        {
            setNeutral();
            current = gameObject.GetComponentInChildren<Text>();
            current.text = curr.ToString("00");
        }
        
		Debug.Log (gameObject.tag);
        
        //StartCoroutine (SpawnWaves ());
    }

	void Update(){
        if (gameObject.tag != "AI")
		    current.text = curr.ToString("00");
	}

	IEnumerator SpawnWaves (){
		while (generate) {
            if (curr <= 4)
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

			shippu.GetComponent<shipController>().island = gameObject.GetComponent<Button>();

			localShips.Add (shippu);
			if (curr >= capacity) {
				curr = capacity;
				generate = false;
			}
			yield return new WaitForSeconds (1);
		}
	}

	public void playerCapture (int start)
	{
		curr += start;
		this.owner = "player";
		gameObject.tag = "Player";
		gameObject.GetComponent<Image> ().color = Color.green;
		generate = true;
//		canvas.GetComponent<playerController> ().maxPopulation += capacity;
		maxpop = canvas.GetComponent<playerController> ().maxPopulation;
		StopCoroutine(SpawnWaves());
		this.StartCoroutine(SpawnWaves());
    }

    public void playerMove(int start)
    {
        curr -= start;
        generate = true;
		StopCoroutine(SpawnWaves());
        this.StartCoroutine(SpawnWaves());
    }

    public void attacked()
    {
        curr = 0;
        foreach (GameObject ship in localShips)
        {
            Destroy(ship);
        }
        generate = true;
        StopCoroutine(SpawnWaves());
        this.StartCoroutine(SpawnWaves());
    }

    public void aiCapture()
    {
        this.owner = "ai";
        gameObject.tag = "AI";
        gameObject.GetComponent<Image>().color = Color.red;
        generate = true;
    
    }

    public void setNeutral ()
	{
		this.owner = "neutral";
		gameObject.tag = "Neutral";
		gameObject.GetComponent<Image> ().color = Color.grey;
		curr = 0;
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
