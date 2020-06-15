using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUiCtrl : MonoBehaviour
{

    public Button Start;
    public Button Stop;
    bool isStartActive = false;

    public void ShowPlayBtn()
    {
        Start.gameObject.SetActive(true);
        Stop.gameObject.SetActive(false);

        isStartActive = true;
    }

    public void ShowStopBtn()
    {
        Start.gameObject.SetActive(false);
        Stop.gameObject.SetActive(true);

        isStartActive = false;
    }

    public void SwitchToOtherBtn()
    {
        isStartActive = !isStartActive;
        if (!isStartActive)
        {
            ShowStopBtn();
        }
        else
        {
            ShowPlayBtn();
        }


    }

}
