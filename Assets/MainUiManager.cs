using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUiManager : MonoBehaviour {

    public static MainUiManager instance;
    public GameObject mainMenu, gameOverScreen, ingameScreen,reloadScreen;
    public float fadetime;
    public Image fadeimage;
    public Ease easeType;

    private void OnEnable()
    {
        EventManager.instance.On_Death += On_Death;
        
    }

    public void NextLevel()
    {
        fadeimage.gameObject.SetActive(true);
        fadeimage.DOFade(1, fadetime).SetEase(easeType).OnComplete(() =>
        {
            ingameScreen.SetActive(true);
            reloadScreen.SetActive(false);
            fadeimage.DOFade(0, fadetime).SetEase(easeType).OnComplete(() =>
            {
                fadeimage.gameObject.SetActive(false);
                EventManager.instance.OnNextLevel();
                //EventManager.instance.OnPlay();
            });
        });
    }

    private void OnDisable()
    {
        EventManager.instance.On_Death -= On_Death;
       
    }

    private void Awake()
    {
        instance = this;
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

    public void ReloadScreen()
    {
        
        fadeimage.gameObject.SetActive(true);
        fadeimage.DOFade(1, fadetime).SetEase(easeType).OnComplete(() =>
        {
            ingameScreen.SetActive(false);
            reloadScreen.SetActive(true);
            fadeimage.DOFade(0, fadetime).SetEase(easeType).OnComplete(() =>
            {
                fadeimage.gameObject.SetActive(false);       
                //EventManager.instance.OnPlay();
            });
        });

    }

    public void ReloadPressed()
    {
        fadeimage.gameObject.SetActive(true);
        fadeimage.DOFade(1, fadetime).SetEase(easeType).OnComplete(() =>
        {
            reloadScreen.SetActive(false);
            ingameScreen.SetActive(true);
            fadeimage.DOFade(0, fadetime).SetEase(easeType).OnComplete(() =>
            {
                EventManager.instance.OnReload();
                fadeimage.gameObject.SetActive(false);
                //EventManager.instance.OnPlay();
            });
        });

    }
}
