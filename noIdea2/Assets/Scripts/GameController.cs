using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    public GameObject ship;
    public GameObject island;
    public Vector3 spawnValues;
    public Canvas canvas;
    //public int x;
    //public int y;
    //public int z;


    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;            
            GameObject shippu = Instantiate(ship) as GameObject;
            shippu.transform.SetParent(canvas.transform);
            shippu.transform.localPosition = spawnPosition;
            shippu.transform.localRotation = spawnRotation;
            yield return new WaitForSeconds(3);
        }
    }
}
