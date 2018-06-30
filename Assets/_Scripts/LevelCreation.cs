using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour {

    public static LevelCreation instance;
    public GameObject[] levels;
    public int currentLevel;

	void Start () {
        int i = Random.Range(0, levels.Length);
        currentLevel = i;
        Instantiate(levels[i], transform,false);
	}

    private void Awake()
    {
        instance = this;
    }

    public void NextLevel()
    {

        int i = Random.Range(0, levels.Length);
        while (i == currentLevel)
        {
            i = Random.Range(0, levels.Length);
        }
        Instantiate(levels[i], transform,false);
        currentLevel = i;
    }
}
