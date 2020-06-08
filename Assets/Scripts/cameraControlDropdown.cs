using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class cameraControlDropdown : MonoBehaviour
{
    Dropdown m_Dropdown;
    public ReadCameraToTexture readCameraToTexture;

    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();

        WebCamDevice[] options =  readCameraToTexture.getcameraDevices();

        if (options != null)
        {
            for (int i = 0; i < options.Length; i++)
            {
                OptionData m_NewData = new Dropdown.OptionData();
                m_NewData.text = options[i].name;
                
                m_Dropdown.options.Add(m_NewData);
            }
        }
        else
        {
            OptionData m_NewData = new Dropdown.OptionData();
            m_NewData.text = "No camera found";

            m_Dropdown.options[0] = m_NewData;
        }

        m_Dropdown.value = 0;

    }


    public void changeSelectedCam(Dropdown change)
    {
        readCameraToTexture.changeSelectedCamera(change.value);
    }

}
