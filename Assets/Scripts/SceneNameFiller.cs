using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNameFiller : MonoBehaviour
{
    public VideoData vd;
    public TMPro.TextMeshProUGUI sceneName;

    private void OnEnable()
    {
        sceneName.text = vd.getCurrentSceneName();

    }
}
