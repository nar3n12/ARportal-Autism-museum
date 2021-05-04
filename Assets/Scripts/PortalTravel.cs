using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTravel : MonoBehaviour
{
    public GameObject room;
    
    //Layer 9: inside portal
    //Layer10: outside portal
    
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
        var doorRend = room.transform.parent.parent.Find("door").gameObject.GetComponentInChildren<Renderer>();
        if (other.name != "AR Camera") 
            return;
        //outside of other world aka portal
        if (transform.position.z > other.transform.position.z)
        {
           // Debug.Log("outside portal");
            if (room.layer != 9) SetLayer(room, 9, true);
            doorRend.enabled = true;


        }
        //when u enter inside portal aka other world
        else   
        {
          //  Debug.Log("inside portal");
            
            if (room.layer != 10) SetLayer(room,10,true);
            doorRend.enabled = false;
            //setting all text to default layer
            foreach (var child in room.GetComponentsInChildren(typeof(Transform), true)) {
                if(child.CompareTag("text"))
                    child.gameObject.layer = 0;
            }
        }
    }

}
