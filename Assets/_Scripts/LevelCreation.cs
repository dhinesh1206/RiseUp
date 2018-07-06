using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour {

    public static LevelCreation instance;
    public List<GameObject> levels, createdLevels;
    public bool testing;
    public float nextLevelInterval, reloadSecond;
    public int totalLevel;

	void Start () {
        totalLevel = levels.Count;
        if (testing)
        {
            StartCoroutine(ReloadLevel());
        }
    }

    private void OnEnable()
    {
        EventManager.instance.On_Play += On_Play;
        EventManager.instance.On_NextLevel += On_NextLevel;
        EventManager.instance.On_Death += On_Death;
        EventManager.instance.On_Reload += On_Reload;
    }


    private void On_Reload()
    {
        GameObject levelCreated = Instantiate(createdLevels[createdLevels.Count -1], transform, false);
        if (testing)
        {
            StartCoroutine(ReloadLevel());
        }
    }

    private void On_NextLevel()
    {
        if (testing)
        {
            StartCoroutine(ReloadLevel());
        }
        StartCoroutine(NextLevelCreate());
    }

    private void OnDisable()
    {
        EventManager.instance.On_Play -= On_Play;
        EventManager.instance.On_Death -= On_Death;
        EventManager.instance.On_Reload -= On_Reload;
        EventManager.instance.On_NextLevel -= On_NextLevel;
    }

    private void On_Death()
    {
        StopAllCoroutines();
    }

    private void On_Play()
    {
        int i = Random.Range(0, levels.Count);
        Instantiate(levels[i], transform, false);
        createdLevels.Add(levels[i]);
        levels.Remove(levels[i]);
      //  StartCoroutine(NextLevelCreate());
    }

    private void Awake()
    {
       
        instance = this;
        totalLevel = levels.Count + 1;
    }

    public IEnumerator NextLevelCreate()
    {
       
        if (levels.Count > 0)
        {
            yield return new WaitForSeconds(nextLevelInterval);
            //EventManager.instance.OnNextLevel();
            int i = Random.Range(0, levels.Count);
            GameObject levelCreated = Instantiate(levels[i], transform, false);
            createdLevels.Add(levels[i]);
            levels.Remove(levels[i]);
           // StartCoroutine(NextLevelCreate());
        } else
        {
            EventManager.instance.OnDeath();
        }
    }


    public IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(reloadSecond);
        MainUiManager.instance.ReloadScreen();
    }
}
