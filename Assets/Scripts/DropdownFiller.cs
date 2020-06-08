using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class DropdownFiller : MonoBehaviour
{
    public VideoData videoData;
    // Start is called before the first frame update
    //This is the Dropdown
    Dropdown m_Dropdown;
    string m_MyString;
    int m_Index;
    
    void Start()
    {
        List<string> options = videoData.getVideoOptions();

        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();


        for(int i=0; i < options.Count; i++)
        {
            OptionData m_NewData = new Dropdown.OptionData();
            m_NewData.text = options[i];
            
            m_Dropdown.options.Add(m_NewData);
        }

        m_Dropdown.value = 0;
        

    }

}
