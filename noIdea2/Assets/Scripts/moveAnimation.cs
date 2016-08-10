using UnityEngine;
using System.Collections;

public class moveAnimation : MonoBehaviour {
    float ElapsedTime;
    float FinishTime;
    public Vector3 Target;
    public Vector3 StartPosition;

    void Start()
    {
        ElapsedTime = 0;
        FinishTime = 5f;
    }

    void Update()
    {
        if (StartPosition != new Vector3(0, 0, 0))
        {
            ElapsedTime += Time.deltaTime;
            //transform.position = Vector3.Lerp(StartPosition, Target, ElapsedTime / FinishTime);
            transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 100);
            //transform.position = Vector3.Lerp(StartPosition, Target, ElapsedTime / FinishTime);
            if (transform.position == Target & transform.position.y != 0)
            {
                Debug.Log(transform.position);
                Debug.Log(Target);
                Destroy(gameObject);
            }
        }
           
    }
    }
