using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class aiController : MonoBehaviour {
	public int maxPopulation;
	public int shipPopulation;
	public List<GameObject> ships;
    public GameObject ship;

	GameObject[] islands;
    GameObject canvas;
    GameObject[] player;

	void Start(){
        canvas = GameObject.Find("Canvas");
        player = canvas.GetComponent<playerController>().islands;
        islands = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject island in islands)  {
            island.SetActive(false);
        }
        ship.GetComponent<Image>().color = Color.red;
        StartCoroutine(SpawnAndShoot());
	}

	void Update(){
        player = canvas.GetComponent<playerController>().islands;
    }

    IEnumerator SpawnAndShoot()
    {
        yield return new WaitForSeconds(5);
        while (true){
            foreach (GameObject island in islands) {             
                island.SetActive(true);
                yield return new WaitForSeconds(3);
                island.SetActive(false);
                int maxIs = 0;
                GameObject maxIss = player[0];
                foreach (GameObject playerIs in player)
                {
                    if (playerIs.GetComponent<islandController>().curr > maxIs)
                        maxIss = playerIs;
                }
                Vector3 spawnPosition = new Vector3(island.transform.position.x, island.transform.position.y, 0);
                Vector3 endPosition = new Vector3(maxIss.transform.position.x, maxIss.transform.position.y, 0);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject shippu = Instantiate(ship) as GameObject;
                shippu.GetComponent<shipController>().enabled = false;
                shippu.transform.SetParent(canvas.transform);
                shippu.transform.position = spawnPosition;
                shippu.transform.localRotation = spawnRotation;
                shippu.GetComponent<moveAnimation>().StartPosition = spawnPosition;
                shippu.GetComponent<moveAnimation>().Target = endPosition;
                shippu.GetComponent<moveAnimation>().islandSrc = island;
                shippu.GetComponent<moveAnimation>().islandDest = maxIss;
            }
        }
        

    }
}