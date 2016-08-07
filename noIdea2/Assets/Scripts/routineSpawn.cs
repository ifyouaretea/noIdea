using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class routineSpawn : MonoBehaviour {
    public GameObject ship;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(ship);
        }

    }
	
	// Update is called once per frame
	void Update () {

    }

}
