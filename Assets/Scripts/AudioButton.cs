using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField ]
    private GameObject eve;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        eve.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
            eve.SetActive(false);
        }
        else
        {
            _audioSource.Play();
            eve.SetActive(true);
        }
        
        
    }
    
}
