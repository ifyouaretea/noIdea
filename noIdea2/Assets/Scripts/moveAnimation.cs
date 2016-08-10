using UnityEngine;
using System.Collections;

public class moveAnimation : MonoBehaviour {
    float ElapsedTime;
    float FinishTime;
    public Vector3 Target;
    public Vector3 StartPosition;
    public GameObject islandSrc;
    public GameObject islandDest;

    void Start()
    {

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
                Destroy(gameObject);
                if (islandSrc.GetComponent<islandController>().owner == "player")
                    islandDest.GetComponent<islandController>().playerCapture(4);
            }
        }
           
    }
}
