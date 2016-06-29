using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public void scoreUpdate(){
		ScoreManager.score = ScoreManager.score + 1;
	}
}
