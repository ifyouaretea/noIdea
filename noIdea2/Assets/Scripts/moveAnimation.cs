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
            islandSrc.GetComponent<islandController>().playerMove(toMove);
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
                    Destroy(gameObject);
                    islandDest.GetComponent<islandController>().playerCapture(toMove);

                }
            }else
            {
                ElapsedTime += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 100);
                if (transform.position == Target & transform.position.y != 0)
                {
                    Destroy(gameObject);
                    islandDest.GetComponent<islandController>().attacked();
                }
            }
        }

    }
}
