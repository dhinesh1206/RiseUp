using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelMovement : MonoBehaviour {
    public float endPosition;
    public float time;
	
	void Start () {
        transform.DOMove(new Vector2(0, endPosition), time, false).SetEase(Ease.Linear).OnComplete(() =>
        {
            LevelCreation.instance.NextLevel();
            Destroy(gameObject);
        });
	}
}
