using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    ItemManager itemManager;

    [SerializeField] GameObject gameObjectStartCall;
    [SerializeField] GameObject gameObjectEndCall;
    [SerializeField] GameObject gameObjectEffectCall;
    [SerializeField] GameObject gameObjectPerfectCall;
    [SerializeField] GameObject gameObjectNothingCall;

    [SerializeField] GameObject gameObjectPanelCombo;

    [SerializeField] Image[] imagesScoreNumbers = new Image[5];
    [SerializeField] Image[] imagesTrayNumbers0 = new Image[2];
    [SerializeField] Image[] imagesTrayNumbers1 = new Image[2];
    [SerializeField] Image[] imagesComboNumbers = new Image[2];

    [SerializeField] Sprite[] spritesSTNumbers = new Sprite[10];
    [SerializeField] Sprite[] spritesComboNumbers = new Sprite[11];

    StartCall startCall;
    EndCall endCall;
    EffectCall effectCall;

    AudioSource[] audioSources;
    public static int scoreForEndScene;

    int score;
    int countGood;
    int countBad;
    int countMax = 60;
    int combo;
    int countRainbow;

    bool isPlaying;

	// Use this for initialization
	void Start () {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();

        startCall = gameObjectStartCall.GetComponent<StartCall>();
        endCall = gameObjectEndCall.GetComponent<EndCall>();
        effectCall = gameObjectEffectCall.GetComponent<EffectCall>();

        audioSources = GetComponents<AudioSource>();

        gameObjectStartCall.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        imagesScoreNumbers[0].sprite = spritesSTNumbers[score % 10];
        imagesScoreNumbers[1].sprite = spritesSTNumbers[score / 10 % 10];
        imagesScoreNumbers[2].sprite = spritesSTNumbers[score / 100 % 10];
        imagesScoreNumbers[3].sprite = spritesSTNumbers[score / 1000 % 10];
        imagesScoreNumbers[4].sprite = spritesSTNumbers[score / 10000 % 10];

        imagesTrayNumbers0[0].sprite = spritesSTNumbers[countMax % 10];
        imagesTrayNumbers0[1].sprite = spritesSTNumbers[countMax / 10 % 10];

        imagesTrayNumbers1[0].sprite = spritesSTNumbers[(countGood + countBad) % 10];
        imagesTrayNumbers1[1].sprite = spritesSTNumbers[(countGood + countBad) / 10 % 10];

        imagesComboNumbers[0].sprite = spritesComboNumbers[combo % 10];
        imagesComboNumbers[1].sprite = combo >= 10 ? spritesComboNumbers[combo / 10 % 10] : spritesComboNumbers[10];

        gameObjectPanelCombo.SetActive(combo >= 2);
	}

    private void FixedUpdate()
    {

       
    }
    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public void FinishGame()
    {
        isPlaying = false;

        GameObject[] gameObjectsItems = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject gameObjectItem in gameObjectsItems) Destroy(gameObjectItem);

        gameObjectEndCall.SetActive(true);
        if(countBad == 0)
        {
            score += 5000;
            gameObjectPerfectCall.SetActive(true);
        }
    }

    public void EndGame()
    {
        scoreForEndScene = score;
        SceneManager.LoadScene("EndScene");
    }

    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnGettingItem(int itemCode)
    {
        switch (itemCode)
        {
            case 1:
                score += 100 + 10 * combo;
                countGood++;
                combo++;
                audioSources[1].time = 0.06f;
                audioSources[1].Play();
                break;
            case 2:
                score += 1;
                countBad++;
                combo = 0;
                audioSources[2].time = 0.0f;
                audioSources[2].Play();
                break;
            case 3:
                int index = countRainbow % 5;
                Debug.Log(index);
                switch (index)
                {
                    case 0:
                        for (int i = 0; i < 3; i++) 
                        {
                            score += 100 + 10 * combo;
                            countGood++;
                            combo++;
                        }
                        break;
                    case 1:
                        countGood++;
                        combo++;
                        GameObject[] gameObjectsItems = GameObject.FindGameObjectsWithTag("Item");
                        foreach (GameObject gameObjectItem in gameObjectsItems) gameObjectItem.GetComponent<Item>().ForciblyDestroy();
                        break;
                    case 2:
                        score += 1000 + 10 * combo;
                        countGood++;
                        combo++;
                        break;
                    case 3:
                        countGood++;
                        combo++;
                        itemManager.ChangeA();
                        gameObjectNothingCall.SetActive(false);
                        break;
                    case 4:
                        countGood++;
                        combo++;
                        countBad = 0;
                        break;
                }
                countRainbow++;
                gameObjectEffectCall.SetActive(false);
                gameObjectEffectCall.SetActive(true);
                effectCall.SetSprite(index);
                audioSources[3].time = 0.0f;
                audioSources[3].Play();
                break;
        }
        if (countGood + countBad >= countMax) FinishGame();
        else if (!itemManager.DoesAExist()) gameObjectNothingCall.SetActive(true);
    }

    public void OnMissingItem(int itemCode)
    {
        switch (itemCode)
        {
            case 1:
                combo = 0;
                break;
            case 2:
                if (itemManager.DoesAExist()) score += 10;
                break;
            case 3:
                combo = 0;
                break;
        }
        if (countGood + countBad >= countMax) FinishGame();
        else if (!itemManager.DoesAExist()) gameObjectNothingCall.SetActive(true);
    }
}
