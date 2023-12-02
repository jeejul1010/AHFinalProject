using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VRAttenuation : MonoBehaviour
{
    private float inputSignal = 0f;

    public AudioSource womanAudio;
    public AudioSource manAudio;

    public GameObject womanText;
    public GameObject manText;
    public GameObject hmdWomanText;
    public GameObject hmdManText;
    
    public Slider womanSlider;
    public Slider manSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        womanAudio.volume = 1.0f;
        manAudio.volume = 1.0f;
        womanSlider.value = womanAudio.volume;
        manSlider.value = manAudio.volume;
        womanText.SetActive(false);
        manText.SetActive(false);
        
        hmdWomanText.SetActive(false);
        hmdManText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        print("manVol: " + manAudio.volume + " womanVol: " + womanAudio.volume);
        if (inputSignal > 0)
        {
            manAudio.volume = 1.0f;
            manSlider.value = manAudio.volume;
            manText.SetActive(false);
            womanAudio.volume = 1 - inputSignal;  
            womanSlider.value = womanAudio.volume;
            if (inputSignal >= 0.5f)
            {
                womanText.SetActive(true);
            }
            else
            {
                womanText.SetActive(false);
            }
            
            hmdManText.SetActive(true);
            hmdWomanText.SetActive(false);
        }
        else if (inputSignal < 0)
        {
            womanAudio.volume = 1.0f;
            womanSlider.value = womanAudio.volume;
            womanText.SetActive(false);
            manAudio.volume = 1 + inputSignal;
            manSlider.value = manAudio.volume;
            if (inputSignal <= -0.5f)
            {
                manText.SetActive(true);
            }
            else
            {
                manText.SetActive(false);
            }
            
            hmdManText.SetActive(false);
            hmdWomanText.SetActive(true);
        }
        else
        {
            manText.SetActive(false);
            womanText.SetActive(false);
            womanAudio.volume = 1 - inputSignal;
            womanSlider.value = womanAudio.volume;
            manAudio.volume = 1 + inputSignal;
            manSlider.value = manAudio.volume;
            
            hmdWomanText.SetActive(false);
            hmdManText.SetActive(false);
        }
    }

    public void updateSignal(float signal)
    {
        inputSignal = signal;
    }
}
