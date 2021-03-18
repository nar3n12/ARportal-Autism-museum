using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTravel : MonoBehaviour
{
    public GameObject room;
    
     
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public static void SetLayer ( GameObject gameObject, int layer, bool includeChildren = false) {
        if (!gameObject) return;
        if (!includeChildren) {
            gameObject.layer = layer;
            return;
        }
 
        foreach (var child in gameObject.GetComponentsInChildren(typeof(Transform), true)) {
            child.gameObject.layer = layer;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.name != "AR Camera") 
            return;
        
        //outside of other world aka portal
        if (transform.position.z > other.transform.position.z)
        {
            Debug.Log("outside portal");
            if (room.layer != 9) SetLayer(room, 9, true);
        }
        //inside portal aka other world
        else   
        {
            Debug.Log("inside portal");
            if (room.layer != 10) SetLayer(room,10,true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
