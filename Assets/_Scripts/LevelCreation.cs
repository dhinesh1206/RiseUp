using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour {

    public static LevelCreation instance;
    public GameObject[] levels;
    public int currentLevel;
    public float nextLevelInterval;

	void Start () {
        int i = Random.Range(0, levels.Length);
        currentLevel = i;
        Instantiate(levels[i], transform,false);
        StartCoroutine(NextLevelCreate());
    }

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator NextLevelCreate()
    {
        yield return new WaitForSeconds(nextLevelInterval);
        int i = Random.Range(0, levels.Length);
        while (i == currentLevel)
        {
            i = Random.Range(0, levels.Length);
        }
        GameObject levelCreated = Instantiate(levels[i], transform, false);
        currentLevel = i;
        StartCoroutine(NextLevelCreate());
    }
}
