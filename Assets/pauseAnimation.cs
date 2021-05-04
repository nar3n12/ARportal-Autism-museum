using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAnimation : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void PauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
