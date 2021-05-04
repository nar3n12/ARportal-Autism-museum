using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = gameObject.GetComponent<VideoPlayer>();
    }

   // private void OnMouseDrag()
    //{
     //   if(_videoPlayer.isPlaying) _videoPlayer.Stop();
    //}

    private void OnMouseDown()
    {
        if (_videoPlayer.isPaused || !_videoPlayer.isPlaying)  _videoPlayer.Play();
        else if (_videoPlayer.isPlaying) _videoPlayer.Pause();

    }
}
