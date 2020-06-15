using System;
using System.Linq;
using GetSocialSdk.Capture.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecordControl : MonoBehaviour
{
	public GameObject capturePreviewMenuUI;
	public GetSocialCapturePreview capturePreview;
	public VideoData videoData;
	public blink recordIndication;
	public syncSceneTiming syncSceneTiming;

	private GetSocialCapture _capture;
	private bool isRecording = false;
	private float preperationTime = 3f;
	private float startRecordingTime;
	private float currentRecordLength;
	

	//	private bool startedFlag = false;
	void Awake()
	{
		_capture = GetComponent<GetSocialCapture>();
	}

	private void Start()
	{

		//capturePreview.GetComponent<RawImage>().enabled = false;
	}

	public void startRecording()
	{
		Invoke("record", preperationTime);
		Debug.Log("record pressed");

		capturePreview.Stop();
		//capturePreview.GetComponent<RawImage>().enabled = false;

		


		currentRecordLength = videoData.getCurrentSceneLength();
		

		
		
	}

	public void record()
	{
		if (!isRecording)
		{
			recordIndication.startBlinking();

			startRecordingTime = Time.realtimeSinceStartup;
			isRecording = true;
			Debug.Log("Start recording");
			_capture.StartCapture();

			Invoke("stopRacording", currentRecordLength);
		}
	}



	public void ShareResult()
	{
		Debug.Log("Starting gif generation");
		Action<byte[]> result = bytes =>
		{
		};
		_capture.GenerateCapture(result);
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	public void stopRacording()
	{
		if (isRecording)
		{
			recordIndication.stopBlinking();
			// stop recording
			_capture.StopCapture();
			Debug.Log("Stop recording");
			isRecording = false;

			showPreview();
		}
	}


	public void showPreview()
	{
		capturePreviewMenuUI.SetActive(true);
		//capturePreview.GetComponent<RawImage>().enabled = true;
		syncSceneTiming.startPlaying();
		//startCapturePreview();
	}

	public void hidePreview()
	{
		capturePreviewMenuUI.SetActive(false);
		//capturePreview.GetComponent<RawImage>().enabled = true;
		stopCapturePreview();
	}

	public void stopCapturePreview()
	{
		capturePreview.Stop();
	}

	public void startCapturePreview()
	{
		capturePreview.Play();
	}
}
