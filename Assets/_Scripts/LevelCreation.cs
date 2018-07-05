using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour {

    public static LevelCreation instance;
    public List<GameObject> levels, createdLevels;
    public float nextLevelInterval;
    public int totalLevel;

	void Start () {
        totalLevel = levels.Count+1;
        //int i = Random.Range(0, levels.Length);
        //currentLevel = i;
        //Instantiate(levels[i], transform,false);
        //StartCoroutine(NextLevelCreate());
    }

    private void OnEnable()
    {
        EventManager.instance.On_Play += On_Play;
        EventManager.instance.On_Death += On_Death;
    }

    private void OnDisable()
    {
        EventManager.instance.On_Play -= On_Play;
        EventManager.instance.On_Death -= On_Death;
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
        StartCoroutine(NextLevelCreate());
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
            EventManager.instance.OnNextLevel();
            int i = Random.Range(0, levels.Count);
            GameObject levelCreated = Instantiate(levels[i], transform, false);
            createdLevels.Add(levels[i]);
            levels.Remove(levels[i]);
            StartCoroutine(NextLevelCreate());
        } else
        {
            EventManager.instance.OnDeath();
        }
    }
}
