using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCall : MonoBehaviour {

    MainManager mainManager;

    AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();

        audioSources = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Beep()
    {
        audioSources[0].time = 0.1f;
        audioSources[0].Play();
    }

    public void StartGame()
    {
        audioSources[1].time = 0.0f;
        audioSources[1].Play();
        mainManager.StartGame();
    }

    public void UnsetActive()
    {
        gameObject.SetActive(false);
    }
}
