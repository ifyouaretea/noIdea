﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class swipeController : MonoBehaviour {
    public GameObject ship;
    public GameObject src;
    public GameObject dest;
    public Canvas canvas;
    public List<GameObject> ships;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    // Use this for initialization
    void Start () {        
	
	}
	
	// Update is called once per frame
	void Update () {
        swipe();
    }

    public void swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            PointerEventData cursor = new PointerEventData(EventSystem.current); // This section prepares a list for all objects hit with the raycast
            cursor.position = Input.mousePosition;
            List<RaycastResult> objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursor, objectsHit);
            int count = objectsHit.Count;
            if (count > 0 & objectsHit[0].gameObject.name != "Button" & objectsHit[0].gameObject.name != "Handle")
            {
                src = objectsHit[0].gameObject;
            }
            else
                src = null;
                dest = null; 
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            PointerEventData cursor = new PointerEventData(EventSystem.current); // This section prepares a list for all objects hit with the raycast
            cursor.position = Input.mousePosition;
            List<RaycastResult> objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursor, objectsHit);
            int count = objectsHit.Count;
            if (count > 0)
                dest = objectsHit[0].gameObject;
            else
                dest = null;

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();
            if (src != null & dest != null & src.GetComponent<islandController>().owner == "player")
            {
                Vector3 spawnPosition = new Vector3(src.transform.position.x, src.transform.position.y, 0);
                Vector3 endPosition = new Vector3(dest.transform.position.x, dest.transform.position.y, 0);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject shippu = Instantiate(ship) as GameObject;
                shippu.GetComponent<shipController>().enabled = false;
                shippu.transform.SetParent(canvas.transform);
                shippu.transform.position = spawnPosition;
                shippu.transform.localRotation = spawnRotation;
                shippu.GetComponent<moveAnimation>().StartPosition = spawnPosition;
                shippu.GetComponent<moveAnimation>().Target = endPosition;
                shippu.GetComponent<moveAnimation>().islandSrc = src;
                shippu.GetComponent<moveAnimation>().islandDest = dest;
            }
        }
    }
}
