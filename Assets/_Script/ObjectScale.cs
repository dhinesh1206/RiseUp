using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectScale : MonoBehaviour {

    public float scaleInTime, scaleOutTime, maxScaleValue,minScaleValue, timeToActivate,intervalTime;
    public bool idle;
    public Ease easetype;

	void Start () {
        StartCoroutine(Activate());
	}

    public IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        if (transform.localScale.x == scaleInTime)
            StartCoroutine(ScaleObject(scaleOutTime, maxScaleValue));
        else
            StartCoroutine(ScaleObject(scaleInTime, minScaleValue));
    }

    IEnumerator ScaleObject(float time, float value)
    {
        print(value);
        yield return new WaitForSeconds(intervalTime);
        transform.DOScale(value, time).SetEase(easetype).OnComplete(() =>
        {
            if (value == scaleInTime)
                StartCoroutine(ScaleObject(scaleInTime,minScaleValue));
            else
                StartCoroutine(ScaleObject(scaleOutTime, maxScaleValue));
        });

    }
}
