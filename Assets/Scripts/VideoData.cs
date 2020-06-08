using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoData : MonoBehaviour
{
    public Scene[] SceneData;
    public VideoPlayer vp;

    [ContextMenu("OnValidate")]
    private void OnValidate()
    {
        for (int i = 0; i < SceneData.Length; i++)
        {
            for (int j = 0; j < SceneData[i].allCharacters.Length; j++)
            {
                //System.Array.Sort(storyboardData[i].allCharacters[j].allFrames, (a, b) => a.name.CompareTo(b.name));
            }
        }
    }


    public List<String> getVideoOptions()
    {
        List<String> videoOptions = new List<string>();

        for (int i = 0; i < SceneData.Length; i++)
        {
            for (int j = 0; j < SceneData[i].allCharacters.Length; j++)
            {
                videoOptions.Add(SceneData[i].allCharacters[j].video.name);
                //System.Array.Sort(storyboardData[i].allCharacters[j].allFrames, (a, b) => a.name.CompareTo(b.name));
            }
        }

        return videoOptions;
    }

    private VideoClip getVideoByName(string name) {


        for (int i = 0; i < SceneData.Length; i++)
        {
            Character myChar = Array.Find(SceneData[i].allCharacters, character => character.video.name == name);
            if (myChar != null) {
                return myChar.video;
            }

        }
        return null;
    }

    public void switchVideo(Dropdown change)
    {
        vp.clip = getVideoByName(change.options[change.value].text);
    }
}
[Serializable]
public class Scene
{
    public string name;
    public Character[] allCharacters;
}

[Serializable]
public class Character
{
    public VideoClip video;
    public string name;

}


