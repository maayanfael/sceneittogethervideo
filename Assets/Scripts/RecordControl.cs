using System;
using System.Linq;
using GetSocialSdk.Capture.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecordControl : MonoBehaviour
{
	public GetSocialCapturePreview capturePreview;
	private GetSocialCapture _capture;
	public GameObject myPrefab;

	//	private bool startedFlag = false;
	void Awake()
	{
		_capture = GetComponent<GetSocialCapture>();
	}

	private void Start()
	{

		capturePreview.GetComponent<RawImage>().enabled = false;
	}

	public void startRacording()
	{
		
		capturePreview.Stop();
		capturePreview.GetComponent<RawImage>().enabled = false;

		Debug.Log("Start recording");

		_capture.StartCapture();
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
		
		// stop recording
		_capture.StopCapture();
		Debug.Log("Stop recording");

		capturePreview.GetComponent<RawImage>().enabled = true;

		capturePreview.Play();



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
