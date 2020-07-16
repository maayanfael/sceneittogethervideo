using GetSocialSdk.Capture.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExportFileUI : MonoBehaviour
{
    public TextMeshProUGUI Path;
    public TextMeshProUGUI Loading;

    private string LoadingText = "Exporting file";
    private string pathChangedText = "";
    private GetSocialCapture FilePathEvent;
    private bool hasFileExported = false;


    // Update is called once per frame
    void Update()
    {   
        if (!hasFileExported)
        {
            if (Time.fixedTime % .9 < .3)
            {
                Loading.text = LoadingText + ".";

            }
            else if (Time.fixedTime % .9 < .6 &&
                Time.fixedTime % .9 > .3)
            {
                Loading.text = LoadingText + "..";
            }
            else
            {
                Loading.text = LoadingText + "...";
            }
        }
        else {
            Loading.text = "Finished";
            Path.text = pathChangedText;

        }

    }


    void OnEnable()
    {
        if (FilePathEvent == null) FilePathEvent = GameObject.FindObjectOfType<GetSocialCapture>();
        hasFileExported = false;
        Path.text = "";
        FilePathEvent.FilePathChangeEvent += ChangePath;


    }
    private void OnDisable()
    {
        if (FilePathEvent)
            FilePathEvent.FilePathChangeEvent -= ChangePath;
    }

    void ChangePath(string textToChangeParam)
    {
        hasFileExported = true;
        pathChangedText = textToChangeParam;
        
    }
}
