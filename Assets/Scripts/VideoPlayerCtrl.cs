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

        vp.loopPointReached += EndReached;

    }


    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Reset video to first frame
        vp.frame = 0;
        RenderTexture.active = vp.targetTexture;
        GL.Clear(true, true, Color.black);
        RenderTexture.active = null;
    }


    public void vpPlay()
    {
        if(!vp.isPlaying)
            vp.Stop();
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
