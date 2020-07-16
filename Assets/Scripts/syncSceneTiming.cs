using GetSocialSdk.Capture.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class syncSceneTiming : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject getSocialCapturePreview;
    public GetSocialCapturePreview capturePreview;
    public VideoData data;

    private float delayTime = 0;


    // Start is called before the first frame update
    private void OnEnable()
    {

        startPlaying();
    }

    [ContextMenu("play")]
    public void startPlaying()
    {
        vp.Stop();
        capturePreview.Stop();


        HideGif();

        ShowTime[] showTimes = data.GetShowTimesOfCurrentCharacter();
        

        vp.Play();
        Invoke("playCapture", 3f);

        Debug.Log("current Time: " + Time.realtimeSinceStartup);
        Debug.Log("play capture Time: " + Time.realtimeSinceStartup + 3f);
        
        if (showTimes[0].start > 3) {
            Invoke("HideGif", 3f);
        }
        for (int i=0; i < showTimes.Length; i++)
        {
            Invoke("ShowGif", showTimes[i].start - .2f);
            Invoke("HideGif", showTimes[i].end + .3f);
            Debug.Log("showing: " + (Time.realtimeSinceStartup + showTimes[i].start));
            Debug.Log("ending: " + (Time.realtimeSinceStartup + showTimes[i].end +.35f));
        }
    }

    public void disableBtns()
    {

    }

    private void playCapture() { capturePreview.Stop(); capturePreview.Play(); }
    private void HideGif() {
        var image = getSocialCapturePreview.GetComponent<RawImage>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
    private void ShowGif() {
        var image = getSocialCapturePreview.GetComponent<RawImage>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

}
