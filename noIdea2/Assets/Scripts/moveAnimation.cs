using UnityEngine;
using System.Collections;

public class moveAnimation : MonoBehaviour {
    float ElapsedTime;
    float FinishTime;
    public Vector3 Target;
    public Vector3 StartPosition;

    void Start()
    {
        //Vector3 StartPosition = new Vector3(0, 0, 0);
        //Target = island.transform.localPosition;
        //StartPosition = Vector3.zero;
        //Target = new Vector3(100,100,100);
        ElapsedTime = 0;
        FinishTime = 5f;
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(StartPosition, Target, ElapsedTime / FinishTime);
    }
}
