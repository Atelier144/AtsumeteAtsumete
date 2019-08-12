using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

    [SerializeField] Image[] imagesEndNumbers = new Image[5];

    [SerializeField] Sprite[] spritesEndNumbers = new Sprite[10];

    int score;

    // Use this for initialization
    void Start () 
    {
        score = MainManager.scoreForEndScene;
    }
	
    // Update is called once per frame
    void Update ()
    {
        imagesEndNumbers[0].sprite = spritesEndNumbers[score % 10];
        imagesEndNumbers[1].sprite = spritesEndNumbers[score / 10 % 10];
        imagesEndNumbers[2].sprite = spritesEndNumbers[score / 100 % 10];
        imagesEndNumbers[3].sprite = spritesEndNumbers[score / 1000 % 10];
        imagesEndNumbers[4].sprite = spritesEndNumbers[score / 10000 % 10];
    }

    public void OnClickButtonRanking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    public void OnClickButtonRetry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickButtonTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
