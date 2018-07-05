using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance;
    public delegate void ParameterlessDelegate();
    public event ParameterlessDelegate On_Play, On_Death, On_Score, On_Restart,On_NextLevel;
    bool death;

    private void Awake()
    {
        instance = this;
    }

    public void OnPlay()
    {
        if (On_Play != null)
            On_Play();
    }

    public void OnDeath()
    {
        if (!death)
        {
            death = true;
            if (On_Death != null)
            {
                On_Death();
            }
        }
    }

    public void OnScore()
    {
        if (On_Score != null)
            On_Score();
    }

    public void OnRestart()
    {
        if (On_Restart != null)
            On_Restart();
    }

    public void OnNextLevel()
    {
        if (On_NextLevel != null)
            On_NextLevel();
    }
}
