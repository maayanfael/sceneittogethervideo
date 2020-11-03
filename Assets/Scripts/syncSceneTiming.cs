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
    private Animator animator; 

    private float delayTime = 0;
    bool shouldStartPlaying = true;
    bool shouldChangeFrames = false;

    private void OnEnable()
    {
        vp.Prepare();
        vp.prepareCompleted += prepered;
        shouldStartPlaying = true;
        animator = GetComponent<Animator>();
    }

    public void prepered(UnityEngine.Video.VideoPlayer vp)
    {
        if (shouldStartPlaying)
        {
            startPlaying();
            shouldStartPlaying = false;
        }
    }

    private void Update()
    {
        if (shouldChangeFrames)
        {
            capturePreview.PlayByMovieFrame((int)vp.frame - 72, (int)vp.frameCount - 72);
        }
    }


    [ContextMenu("play")]
    public void startPlaying()
    {
        vp.Stop();
        capturePreview.Stop();

        HideGif();

        ShowTime[] showTimes = data.GetShowTimesOfCurrentCharacter();
        float sceneLength = data.getCurrentSceneLength();
        shouldChangeFrames = true;
        vp.Play();

        Debug.Log("Movie frameCount:  " + vp.frameCount + ", frameRate: " + vp.frameRate);
        Invoke("playCapture", 3f);
        

        if (showTimes[0].start > 3)
        {
            Invoke("HideGif", 3f);
        }
        for (int i = 0; i < showTimes.Length; i++)
        {
            Invoke("ShowGif", showTimes[i].start - .2f);
            if(showTimes[i].end != sceneLength)
                Invoke("HideGif", showTimes[i].end + .3f);
        }
    }

    public void disableBtns()
    {

    }

    private void playCapture() {
        capturePreview.Stop();
        capturePreview.Play();
    }
    private void HideGif() {
        var image = getSocialCapturePreview.GetComponent<RawImage>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
    private void ShowGif() {
        var image = getSocialCapturePreview.GetComponent<RawImage>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public void FadeOutAnim()
    {
        animator.SetTrigger("Out");
    }

}
