using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : MonoBehaviour
{
    
    private GameObject[] roomArr;

    public GameObject room1;
    public GameObject room2;
    public GameObject room3;

    private Animator anim;
    private Transform[] children;
    
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("ROOM SELECTOR ACTIVATED");
        roomArr = new GameObject[3];
        roomArr[0] = room1;
        roomArr[1] = room2;
        roomArr[2] = room3;
        foreach (var room in roomArr)
        {
            room.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)  //other = door
    {
       
        if (other.name != "door")
        {
            return;
        }

        //var doorRend = other.transform.GetComponentInChildren<Renderer>(true);
        //outside of other world aka portal
        if (transform.position.z+2f > other.transform.position.z)
        {
            Debug.Log(other.name);

            
            //turn off other rooms
            foreach (var room in roomArr)
            {
                // other = collider of the door which we come in
        
                var thisRoom = other.transform.Find("RoomMade").gameObject;

                if (thisRoom == room)
                {
                    room.SetActive(true);
                    //doorRend.enabled = false;
                    //anim = thisRoom.transform.parent.Find("door").gameObject.GetComponent<Animator>();
                    //anim.Play("doorClose");
                    Debug.Log("This room enabled");
                }
                else
                {
                    room.SetActive(false);
                    //doorRend.enabled = true;
                    //anim.Play("doorOpen");
                    Debug.Log("This room disabled");
                }
            }
            
        }
        //inside portal aka other world
        else   
        {
            //turn off all rooms
            foreach (var room in roomArr)
            {
                room.SetActive(false);
                //doorRend.enabled = true;
                Debug.Log("ALL disabled");
            }
        }
    }
}
