using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUiCtrl : MonoBehaviour
{

    public Button StartBtn;
    public Button StopBtn;
    public Button RecordBtn;
    bool isStartBtnActive = false;
    public VideoData vd;

    private void Start()
    {
        vd.CharacterVp.loopPointReached += EndReached;
    }

    public void ShowPlayBtn()
    {
        StartBtn.gameObject.SetActive(true);
        StopBtn.gameObject.SetActive(false);

        isStartBtnActive = true;
    }

    public void ShowStopBtn()
    {   
        StartBtn.gameObject.SetActive(false);
        StopBtn.gameObject.SetActive(true);

        isStartBtnActive = false;
        
    }

    public void ShowRecordBtn() {
        RecordBtn.gameObject.SetActive(true);

    }
    public void HideRecordBtn() {
        RecordBtn.gameObject.SetActive(false);
    }


    public void HideStopBtn()
    {
        StartBtn.gameObject.SetActive(false);
        StopBtn.gameObject.SetActive(false);

        isStartBtnActive = false;
    }

    public void SwitchToOtherBtn()
    {
        isStartBtnActive = !isStartBtnActive;
        if (!isStartBtnActive)
        {
            ShowStopBtn();
        }
        else
        {
            ShowPlayBtn();
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        ShowPlayBtn();
    }

}
