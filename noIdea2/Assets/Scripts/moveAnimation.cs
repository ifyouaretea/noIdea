using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveAnimation : MonoBehaviour
{
    float ElapsedTime;
    float FinishTime;
    public Vector3 Target;
    public Vector3 StartPosition;
    public GameObject islandSrc;
    public GameObject islandDest;
    private List<GameObject> numShips;
	int toMove;
    void Start()
    {
        if (islandSrc.GetComponent<islandController>().owner == "player")
        {
            numShips = islandSrc.GetComponent<islandController>().localShips;
            toMove = (int)(0.5 * numShips.Count);
            Debug.Log("moving: " + toMove);
            numShips.RemoveRange(1, toMove);
            for (int i = toMove - 1; i > (numShips.Count - toMove); i--)
            {
                Destroy(numShips[i]);
            }
            islandSrc.GetComponent<islandController>().generate = true;
			//islandSrc.GetComponent<islandController>().playerCapture(toMove);
            Debug.Log(numShips.Count);

        }

    }

    void Update()
    {
        if (StartPosition != new Vector3(0, 0, 0))
        {
            ElapsedTime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 100);
            if (transform.position == Target & transform.position.y != 0)
            {
                Debug.Log(transform.position);
                Debug.Log(Target);
				Debug.Log (toMove);
                Destroy(gameObject);
				islandDest.GetComponent<islandController> ().playerCapture(toMove);

            }
        }

    }
}
