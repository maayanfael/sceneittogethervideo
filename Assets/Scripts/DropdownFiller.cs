using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class DropdownFiller : MonoBehaviour
{
    public VideoData videoData;
    // Start is called before the first frame update
    //This is the Dropdown


    string SceneDropdownName = "SceneDropdown";
    string CharacterDropdownName = "CharDropdown";
    int m_Index;

    void Start()
    {
        fillSceneDropdown();
    }

    public void fillCharDropdown()
    {
        TMP_Dropdown m_Dropdown;

        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GameObject.Find(CharacterDropdownName).GetComponent<TMP_Dropdown>();


        List<string> options = videoData.getVideoOptions();

        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();


        for (int i = 0; i < options.Count; i++)
        {
            TMP_Dropdown.OptionData m_NewData = new TMP_Dropdown.OptionData();
            m_NewData.text = "Playing as<b> " + options[i] + " </b>";

           m_Dropdown.options.Add(m_NewData);
        }
        
        m_Dropdown.value = 0;
        m_Dropdown.captionText.text = "Playing as<b> " + options[0] + " </b>";
        
    }

    private void fillSceneDropdown()
    {
        TMP_Dropdown m_Dropdown;
        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GameObject.Find(SceneDropdownName).GetComponent<TMP_Dropdown>();


        List<string> options = videoData.getScenesOptions();

        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();


        for (int i = 0; i < options.Count; i++)
        {
            TMP_Dropdown.OptionData m_NewData = new TMP_Dropdown.OptionData();
            m_NewData.text = options[i];

            m_Dropdown.options.Add(m_NewData);
        }

        m_Dropdown.value = 0;
        m_Dropdown.captionText.text = options[0];

        fillCharDropdown();
    }


}
