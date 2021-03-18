using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalTransport : MonoBehaviour
{

    public Material[] materials;
    
    // Start is called before the first frame update
   private void Start()
    {
        Debug.Log("started");
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
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
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
            }
        }
        //inside portal aka other world
        else   
        {
            Debug.Log("inside portal");
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
        }
    }

   
}
