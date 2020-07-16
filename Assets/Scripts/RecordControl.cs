using System;
using System.Linq;
using GetSocialSdk.Capture.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecordControl : MonoBehaviour
{

    #region Public fields
    public GameObject capturePreviewMenuUI;
	public GameObject recorderScreenUI;
	public GameObject exportMenuUI;
	public GetSocialCapturePreview capturePreview;
	public VideoData videoData;
	public blink recordIndication;
	public syncSceneTiming syncSceneTiming;
    public TextMeshProUGUI ScreenTitle;
    #endregion


    #region Private fields
    private GetSocialCapture _capture;
	private bool isRecording = false;
	private float preperationTime = 3f;
	private float startRecordingTime;
	private float currentRecordLength;

    private float StartTimeDebug;

    #endregion

    #region Unity methods
    //	private bool startedFlag = false;
    void Awake()
	{
		_capture = GetComponent<GetSocialCapture>();
	}

	private void Start()
	{
        //capturePreview.GetComponent<RawImage>().enabled = false;
    }

    #endregion


    #region Public methods

    public void StartRecording()        
	{
        capturePreview.Clear();
        currentRecordLength = videoData.getCurrentSceneLength();
        GetSocialCapture.ContentFolderName = videoData.getCurrentSceneName();
        GetSocialCapture.GifName = videoData.getCurrentCharacterName();

        Invoke("Record", preperationTime);
        Invoke("StopRacording", currentRecordLength);
        Debug.Log("record pressed");

		capturePreview.Stop();
		//capturePreview.GetComponent<RawImage>().enabled = false;
        
	}


	public void ShareResult()
	{
		Debug.Log("Starting gif generation");
		Action<byte[]> result = bytes =>
		{
		};
		_capture.GenerateCapture(result);
        exportMenuUI.SetActive(true);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HideExportMenu()
    {
        exportMenuUI.SetActive(false);
    }

    public void StopRacording()
	{
		if (isRecording)
		{
			recordIndication.stopBlinking();
			// stop recording
			_capture.StopCapture();
			Debug.LogWarning("Stop recording, recorded: " + Time.realtimeSinceStartup+ " Took "+ (Time.realtimeSinceStartup-startRecordingTime));
			isRecording = false;

			ShowPreview();
		}
	}


	public void ShowPreview()
	{
		capturePreviewMenuUI.SetActive(true);
        recorderScreenUI.SetActive(false);

	}


	public void HidePreview()
	{
        recorderScreenUI.SetActive(true);
        capturePreviewMenuUI.SetActive(false);

		StopCapturePreview();
	}

    public void SetScreenTitle()
    {
        ScreenTitle.text = "Playing As " + videoData.getCurrentCharacterName();
    }

    #endregion


    #region Private methods

    private void Record()
    {
        if (!isRecording)
        {
            recordIndication.startBlinking();

            startRecordingTime = Time.realtimeSinceStartup;
            isRecording = true;
            Debug.Log("Start recording time: " + startRecordingTime);
            _capture.StartCapture();


        }
    }

    private void StopCapturePreview()
    {
        capturePreview.Stop();
    }

    private void StartCapturePreview()
    {
        capturePreview.Play();
    }

    
    #endregion
}
