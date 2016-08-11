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
    private int numShips;
    public GameObject slider;
	int toMove;
    void Start()
    {
        if (islandSrc.GetComponent<islandController>().owner == "player")
        {
            slider = GameObject.Find("Slider");
            float val = slider.GetComponent<allocationSliderText>().allocationSlider.value;
            numShips = islandSrc.GetComponent<islandController>().curr;
            toMove = (int)(val*0.25 * numShips);
            Debug.Log("VAL:" + toMove);
            //numShips.RemoveRange(1, toMove);
            //for (int i = toMove - 1; i > (numShips.Count - toMove); i--)
            //{
            //    Destroy(numShips[i]);
            //}
            islandSrc.GetComponent<islandController>().playerMove(toMove);
			//islandSrc.GetComponent<islandController>().playerCapture(toMove);
            Debug.Log(numShips);

        }

    }

    void Update()
    {
        if (StartPosition != new Vector3(0, 0, 0))
        {
            if (islandSrc.GetComponent<islandController>().owner == "player")
            {
                ElapsedTime += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 100);
                if (transform.position == Target & transform.position.y != 0)
                {
                    Debug.Log(transform.position);
                    Debug.Log(Target);
                    Debug.Log(toMove);
                    Destroy(gameObject);
                    islandDest.GetComponent<islandController>().playerCapture(toMove);

                }
            }else
            {
                ElapsedTime += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 100);
                if (transform.position == Target & transform.position.y != 0)
                {
                    Debug.Log(transform.position);
                    Debug.Log(Target);
                    Debug.Log(toMove);
                    Destroy(gameObject);
                    islandDest.GetComponent<islandController>().attacked();

                }
            }
        }

    }
}
