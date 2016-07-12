using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public void scoreUpdate(){
		ScoreManager.Instance.score += 1;
	}

	public void Retry(){
		ScoreManager.Instance.Retry ();
	}
}
