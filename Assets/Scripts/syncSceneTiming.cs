using GetSocialSdk.Capture.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class syncSceneTiming : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject getSocialCapturePreview;
    public GetSocialCapturePreview capturePreview;
    public VideoData data;

    private float delayTime = 3f;
    // Start is called before the first frame update


    [ContextMenu("play")]
    public void startPlaying()
    {
        vp.Stop();
        capturePreview.Stop();
        HideGif();

        ShowTime[] showTimes = data.GetShowTimesOfCurrentCharacter();
        vp.Play();
        Invoke("playCapture", 3f);
        
        for (int i=0; i < showTimes.Length; i++)
        {
            Invoke("ShowGif", showTimes[i].start -0.3f + delayTime);
            Invoke("HideGif", showTimes[i].end + 0.3f + delayTime);
        }
    }

    private void playCapture() { capturePreview.Play(); }
    private void HideGif() { getSocialCapturePreview.SetActive(false); }
    private void ShowGif() { getSocialCapturePreview.SetActive(true); }

}
