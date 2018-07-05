using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUiManager : MonoBehaviour {


    public GameObject mainMenu, gameOverScreen, ingameScreen;
    public float fadetime;
    public Image fadeimage;
    public Ease easeType;

    private void OnEnable()
    {
        EventManager.instance.On_Death += On_Death;
    }

    private void OnDisable()
    {
        EventManager.instance.On_Death -= On_Death;
    }

    private void On_Death()
    {
        GameOver();
    }

    public void PlayGame()
    {
        fadeimage.gameObject.SetActive(true);
        fadeimage.DOFade(1, fadetime).SetEase(easeType).OnComplete(() =>
        {
            mainMenu.SetActive(false);
            ingameScreen.SetActive(true);
            fadeimage.DOFade(0, fadetime).SetEase(easeType).OnComplete(() =>
            {
                fadeimage.gameObject.SetActive(false);
                EventManager.instance.OnPlay();
            });
        });
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        fadeimage.gameObject.SetActive(true);
        fadeimage.DOFade(1, fadetime).SetEase(easeType).OnComplete(() =>
        {
            ingameScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            fadeimage.DOFade(0, fadetime).SetEase(easeType).OnComplete(() =>
            {
                fadeimage.gameObject.SetActive(false);
                //EventManager.instance.OnPlay();
            });
        });       
    }
}
