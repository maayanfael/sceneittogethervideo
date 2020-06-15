using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoPlayerCtrl : MonoBehaviour
{
    VideoPlayer vp;

    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    public void vpPlay()
    {
        if(!vp.isPlaying)
            vp.Play();
    }

    public void vpPause()
    {
        if (vp.isPlaying)
            vp.Pause();
    }

    public void vpStop()
    {
        if (vp.isPlaying)
            vp.Stop();
    }

    public void vpPlayPause()
    {
        // this object was clicked - do something
        if (vp.isPlaying)
            vp.Pause();
        else
            vp.Play();
    }
}
