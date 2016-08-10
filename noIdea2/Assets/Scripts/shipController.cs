using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shipController : MonoBehaviour {
    //public Button island;
    public Vector3 rotateAbout;
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //the sphere gameObject     
        
    void FixedUpdate() {
		char size = island.GetComponent<islandController>().size;
		if (size == 's')
			transform.RotateAround(island.transform.position, Vector3.back, 40 * Time.deltaTime);
		if (size == 'm')
        	transform.RotateAround(island.transform.position, Vector3.back, 20 * Time.deltaTime);
		if (size == 'l')
			transform.RotateAround(island.transform.position, Vector3.back, 15 * Time.deltaTime);
    }
}
