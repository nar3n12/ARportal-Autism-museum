using System;
using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class TtsController : MonoBehaviour
{
    private const string LANG_CODE = "en-US";
    private bool speaking;
    
   // [SerializeField] string textToSay;
   
    private void Start()
    {
        Setup(LANG_CODE);   //sets speech to text language as en-US 
        speaking  = false;
        Debug.Log("Started, not speaking");

        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
       
        CheckPermission();
        
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
       
    }

    #region TextToSpeech

    public void StartSpeaking(string message)
    {
        speaking = true;
        TextToSpeech.instance.StartSpeak(message);
        Debug.Log("Speaking");
    }

    void OnSpeakStart()
    {
        Debug.Log("start");
    }

    void OnSpeakStop()
    {
        Debug.Log("Stop");
    }

    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
        Debug.Log("stopped speaking");
        speaking = false;
    }

    public bool isSpeaking()
    {
        return speaking;
    }
    
    #endregion

    /**
    private void OnMouseDown()
    {
        Debug.Log("click!");
        if(!speaking) StartSpeaking(textToSay);
        else if(speaking) StopSpeaking();
    }  **/

    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1,1);
    }
}
