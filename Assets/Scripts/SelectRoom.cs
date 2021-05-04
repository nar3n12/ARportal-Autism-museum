using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRoom : MonoBehaviour
{
    private GameObject door1;
    private GameObject door2;
    private GameObject door3;
    private GameObject[] doorArr;

    [SerializeField]
    private Animation doorOpen;
    [SerializeField]
    private Animation doorClose;

    private GameObject Room1;
    private GameObject Room2;
    private GameObject Room3;
    private GameObject[] RoomArr;

    [SerializeField]
    private Material transparentMaterial;
    [SerializeField]
    private Material defaultMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        door1 = GameObject.Find("doorlayout1");
        door2 = GameObject.Find("doorlayout2");
        door3 = GameObject.Find("doorlayout3");

        doorArr = new GameObject[3];
        doorArr[0] = door1;
        doorArr[1] = door2;
        doorArr[2] = door3;
        CloseAllDoors();
        
        Room1 = GameObject.Find("Room1");
        Room2 = GameObject.Find("Room2");
        Room3 = GameObject.Find("Room3");
        
        RoomArr = new GameObject[3];
        RoomArr[0] = Room1;
        RoomArr[1] = Room2;
        RoomArr[2] = Room3;
        CloseAllRooms();
    }

    private void CloseAllDoors()
    {
        foreach (var door in doorArr)
        {
            Debug.Log(door.name);
            door.transform.Find("door").GetComponent<Renderer>().material = defaultMaterial;
            //currentMat.material = defaultMaterial;

        }
    }

    private void CloseAllRooms()
    {
        foreach (var room in RoomArr)
        {
            Debug.Log(room.name);
            room.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        /**
        if (selection != null)
        {
           Debug.Log("doors closed ");
            CloseAllDoors();
            CloseAllRooms();
            selection = null;
        }  **/
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                for (var i = 0; i < 3; i++)
                {
                    var door = doorArr[i].transform.Find("door").gameObject;
                    if (hit.transform.gameObject == door)
                    {
                        Debug.Log("Hit door: "+doorArr[i]);
                        var doorMat = door.transform.GetComponent<Renderer>().material;
                        if (doorMat == defaultMaterial)
                        {
                            CloseAllRooms();
                            RoomArr[i].SetActive(true);
                            CloseAllDoors();
                            door.GetComponent<Renderer>().material = transparentMaterial;
                            
                        }
                        else if(doorMat == transparentMaterial)
                        {
                            CloseAllDoors();
                            CloseAllRooms();
                            
                        }
                        //selection = hit.transform;
                    }
                }
                /**
                 if (hit.transform.gameObject == door1)
                {
                    if (door1.activeInHierarchy)
                    {
                        Room1.SetActive(true);
                        door1.SetActive(false);
                    }
                    else
                    {
                        door1.SetActive(true);
                        Room1.SetActive(false);
                    }
                    
                }  **/
            }
        } 
        
        
    }
}
