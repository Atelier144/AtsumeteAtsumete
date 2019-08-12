using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleManager : MonoBehaviour {

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider sliderBGM;
    [SerializeField] Slider sliderSE;

    static float currentSliderBGMValue;
    static float currentSliderSEValue;

	// Use this for initialization
	void Start () {
        sliderBGM.value = currentSliderBGMValue;
        sliderSE.value = currentSliderSEValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPushButtonStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnValueChangedSliderBGM()
    {
        currentSliderBGMValue = sliderBGM.value;
        audioMixer.SetFloat("BGM", sliderBGM.value);
    }

    public void OnValueChangedSliderSE()
    {
        currentSliderSEValue = sliderSE.value;
        audioMixer.SetFloat("SE", sliderSE.value);
    }
}
