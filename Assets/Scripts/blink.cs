using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    public GameObject gameObject;
    public Renderer renderer;
    bool isBlinking = false;

    private void Start()
    {
        stopBlinking();
    }
    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            if (Time.fixedTime % .9 < .6)
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
            }
        }
    }

    public void startBlinking()
    {
        isBlinking = true;
        gameObject.SetActive(true);
    }

    public void stopBlinking()
    {
        gameObject.SetActive(false);
        isBlinking = false;
        renderer.enabled = false;
    }
}
