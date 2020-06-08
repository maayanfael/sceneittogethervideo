using GetSocialSdk.Capture.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachDebug : MonoBehaviour
{
    //private ManageStoryBoardFiles Debugger;
    private ReadCameraToTexture Debugger2;
    private GetSocialCapture Debugger3;
    public Text textBox;
    private string textToChange;
    private bool hasTextChanged = false;


    private void Reset()
    {
        //if (Debugger == null) Debugger = GameObject.FindObjectOfType<ManageStoryBoardFiles>();
        if (Debugger2 == null) Debugger2 = GameObject.FindObjectOfType<ReadCameraToTexture>();
        if (Debugger3 == null) Debugger3 = GameObject.FindObjectOfType<GetSocialCapture>();


    }
    private void Awake()
    {
        Reset();
    }
    private void Update()
    {
        if (hasTextChanged) {
            textBox.text = textToChange;
            hasTextChanged = false;
        }
        

    }

    void OnEnable()
    {//TODO fix reference
        //Debugger.onDebug += ChangeText;
        //Debugger2.onDebug += ChangeText;
        Debugger3.onDebug += ChangeText;

    }
    private void OnDisable()
    {
       // if (Debugger)
         //   Debugger.onDebug -= ChangeText;
       // if (Debugger2)
           // Debugger2.onDebug -= ChangeText;
         if (Debugger3)
          Debugger3.onDebug -= ChangeText;
    }

    void ChangeText(string textToChangeParam)
    {
        hasTextChanged = true;
        textToChange = textToChangeParam;
    }
}
