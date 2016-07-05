using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreManager : MonoBehaviour {

	public int score;
	GameObject retry;
	Text high;
	Text text;
	int highscore;

	public static ScoreManager Instance;
		
	void Awake(){
		Instance = this;
		text = GameObject.Find("Count Text").GetComponent<Text> ();
		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if (gameObj.tag == "Retry"){
				retry = gameObj;
				retry.SetActive(false);
			}
			if (gameObj.tag == "highscore"){
				high = gameObj.GetComponent<Text> ();
			}

		}
		highscore = 0;
	}

	void Start(){
		score = 0;
	}

	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
		high.text = "High Score: " + highscore;
	}

	public void end(){
		retry.SetActive (true);
		if (score > highscore) {
			highscore = score;
			high.text = "High Score: " + highscore;
		}
		Debug.Log (highscore);
	}


	public void Retry(){
		retry.SetActive (false);
		Timer.Instance.Retry ();
		Start ();
	}

	public void Save()	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.highscore = highscore;
	
		bf.Serialize(file, data);
		file.Close();
	}

	public void Load()	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))	{
			
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			// update score
			highscore = data.highscore;
			score = 0;

		}
	}
}
[Serializable]
class PlayerData{
	public int highscore;
} 
