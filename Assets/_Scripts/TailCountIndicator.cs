using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailCountIndicator : MonoBehaviour {

    public static TailCountIndicator instance;
    public int count;
    public Transform target;
    public Camera cam;
    public Text scoreText;
    public FollowStart followStart;

    public void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        scoreText.transform.position = screenPos;
       
    }

    public void UpdateCount () {
        count = followStart.tailCount;
        scoreText.text = count.ToString();
    }

    private void Awake()
    {
        instance = this;
    }
}
