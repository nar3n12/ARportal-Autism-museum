using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StopVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        videoPlayer.Stop();
    }
}
