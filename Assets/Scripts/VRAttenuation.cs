using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VRAttenuation : MonoBehaviour
{
    private float inputSignal = 0f;

    public AudioSource womanAudio;
    public AudioSource manAudio;

    public GameObject womanText;
    public GameObject manText;
    
    // Start is called before the first frame update
    void Start()
    {
        womanAudio.volume = 1.0f;
        manAudio.volume = 1.0f;
        womanText.SetActive(false);
        manText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        print("manVol: " + manAudio.volume + " womanVol: " + womanAudio.volume);
        if (inputSignal > 0)
        {
            manAudio.volume = 1.0f;
            manText.SetActive(false);
            womanAudio.volume = 1 - inputSignal;
            if (inputSignal >= 0.5f)
            {
                womanText.SetActive(true);
            }
            else
            {
                womanText.SetActive(false);
            }
        }
        else if (inputSignal < 0)
        {
            womanAudio.volume = 1.0f;
            womanText.SetActive(false);
            manAudio.volume = 1 + inputSignal;
            if (inputSignal <= -0.5f)
            {
                manText.SetActive(true);
            }
            else
            {
                manText.SetActive(false);
            }
        }
        else
        {
            manText.SetActive(false);
            womanText.SetActive(false);
            womanAudio.volume = 1 - inputSignal;
            manAudio.volume = 1 + inputSignal;
        }
    }

    public void updateSignal(float signal)
    {
        inputSignal = signal;
    }
}
