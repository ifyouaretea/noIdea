using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shipController : MonoBehaviour {
    public Button island;
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //the sphere gameObject     
        
    void FixedUpdate() {
        //Vector3 spawnPosition = new Vector3(-250, 40, 0);
        //Quaternion target = Quaternion.Euler(10, 0, 0);
        //transform.rotation = Quaternion.Slerp(enIsland.position, target, 20 * Time.deltaTime);
        transform.RotateAround(island.transform.position, Vector3.back, 20 * Time.deltaTime);
    }
}
