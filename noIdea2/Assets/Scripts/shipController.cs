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

        transform.RotateAround(island.transform.position, Vector3.back, 20 * Time.deltaTime);
    }
}
