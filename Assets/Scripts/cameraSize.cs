using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSize : MonoBehaviour
{
    private Camera m_OrthographicCamera;
    public Transform cameraPlace;
    //These are the positions and dimensions of the Camera view in the Game view
    public float m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight;

    void Start()
    {
        m_OrthographicCamera = GetComponent<Camera>();


       
        //If the Camera exists in the inspector, enable orthographic mode and change the size
        if (m_OrthographicCamera)
        {
            changeRatio();

        }
    }

    [ContextMenu("changeRatio")]
    public void changeRatio()
    {
        m_OrthographicCamera.aspect = (float)(m_ViewWidth / m_ViewHeight);
        
        m_OrthographicCamera.pixelRect = new Rect(cameraPlace.position.x, cameraPlace.position.y, m_ViewWidth, m_ViewHeight);
        
    }
}