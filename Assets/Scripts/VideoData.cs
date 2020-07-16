using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoData : MonoBehaviour
{
    public Scene[] SceneData;
    public VideoPlayer CharacterVp;
    public VideoPlayer SceneOriginalVp;

    private int currentSceneIndex = 0;
    private int currentCharacterIndex = 0;

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

    private void Start()
    {
        CharacterVp.clip = SceneData[currentSceneIndex].allCharacters[currentCharacterIndex].video;
        SceneOriginalVp.clip = SceneData[currentSceneIndex].origial;
    }


    public List<String> getVideoOptions()
    {
        List<String> videoOptions = new List<string>();

        for (int j = 0; j < SceneData[currentSceneIndex].allCharacters.Length; j++)
        {
            videoOptions.Add(SceneData[currentSceneIndex].allCharacters[j].video.name);
            //System.Array.Sort(storyboardData[i].allCharacters[j].allFrames, (a, b) => a.name.CompareTo(b.name));
        }


        return videoOptions;
    }

    public List<String> getScenesOptions()
    {
        List<String> videoOptions = new List<string>();

        for (int i = 0; i < SceneData.Length; i++)
        {
            videoOptions.Add(SceneData[i].name);
            //System.Array.Sort(storyboardData[i].allCharacters[j].allFrames, (a, b) => a.name.CompareTo(b.name));
        }

        currentCharacterIndex = 0;
        return videoOptions;
    }



    private int getVideoIndexByName(string name) {


        for (int i = 0; i < SceneData.Length; i++)
        {
            int myChar = Array.FindIndex(SceneData[i].allCharacters, character => character.video.name == name);
            if (myChar != -1) {
                currentSceneIndex = i;
                currentCharacterIndex = myChar;

                return myChar;


            }

        }
        return 0;
    }


    private int getSceneIndexByName(string name)
    {

        int myScene = Array.FindIndex(SceneData, sc => sc.name == name);
        if (myScene != -1)
        {
            currentSceneIndex = myScene;
            return myScene;
        }

    
        return 0;
    }


    public void switchVideo(Dropdown change)
    {
        currentCharacterIndex = getVideoIndexByName(change.options[change.value].text);
        CharacterVp.clip = SceneData[currentSceneIndex].allCharacters[currentCharacterIndex].video;
        CharacterVp.Prepare();
    }

    public void switchScene(Dropdown change)
    {
        currentSceneIndex = getSceneIndexByName(change.options[change.value].text);
        CharacterVp.clip = SceneData[currentSceneIndex].allCharacters[0].video;
        CharacterVp.Prepare();
        SceneOriginalVp.clip = SceneData[currentSceneIndex].origial;
        SceneOriginalVp.Prepare();
    }

    public float getCurrentSceneLength()
    {
        return SceneData[currentSceneIndex].length;
    }

    public string getCurrentSceneName()
    {
        return SceneData[currentSceneIndex].name;
    }

    public string getCurrentCharacterName()
    {
        return SceneData[currentSceneIndex].allCharacters[currentCharacterIndex].video.name;
    }


    public ShowTime[] GetShowTimesOfCurrentCharacter()
    {
        return SceneData[currentSceneIndex].allCharacters[currentCharacterIndex].showTimes;
    }

}



[Serializable]
public class Scene
{
    public string name;
    public Character[] allCharacters;
    public float length;
    public VideoClip origial;
}

[Serializable]
public class Character
{
    public VideoClip video;
    public ShowTime[] showTimes;

}

[Serializable]
public class ShowTime {
    public float start;
    public float end;
}


