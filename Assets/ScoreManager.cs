using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float score, highScore, scoreMultipler, slowdownLenght;
    public Text scoreText,highScoreText, gameoverScoreText, gameoverHighScore,levelCountText;
    public bool playing,highscoreReached;

    private void OnEnable()
    {
        EventManager.instance.On_Play += On_Play;
        EventManager.instance.On_Death += On_Death;
        EventManager.instance.On_NextLevel += On_NextLevel;
    }

    private void OnDisable()
    {
        EventManager.instance.On_Play -= On_Play;
        EventManager.instance.On_Death -= On_Death;
        EventManager.instance.On_NextLevel -= On_NextLevel;
    }

    private void Start()
    {
        levelCountText.text = "Current Level"  + " 1  / " + (LevelCreation.instance.totalLevel).ToString();
    }

    private void On_NextLevel()
    {
        levelCountText.text = "Current Level" + (LevelCreation.instance.createdLevels.Count +1 ).ToString() + " / " + (LevelCreation.instance.totalLevel).ToString();
        StartCoroutine(LevelScore());
    }

    IEnumerator LevelScore()
    {
        yield return new WaitForSeconds(2f);
        score = score + FollowStart.instance.currentChild * 100;
    }

    private void On_Death()
    {
        playing = false;
        PlayerPrefs.SetFloat("HighScore", highScore);
        gameoverScoreText.text = scoreText.text;
        gameoverHighScore.text = highScoreText.text;
    }

    private void On_Play()
    {
        playing = true;
        StartPlaying();
    }

    void StartPlaying () {
        score = 0;
        highScore = PlayerPrefs.GetFloat("HighScore");
        print(highScore);
        highScoreText.text = "HighScore : " + highScore.ToString("f0");
    }
	
	void Update () {
       
        if (playing)
        {
            score = score + (scoreMultipler * Time.deltaTime);
            scoreText.text = "Score : " + score.ToString("f0");
            if (score > highScore)
            {
                if(!highscoreReached)
                {
                    highscoreReached = true;
                }
                highScore = score;
                highScoreText.text = "HighScore : " + highScore.ToString("f0");
            }
        }
	}
}
