using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectsFadeOut : MonoBehaviour {

    public float timeToActivate, fadeOutime,fadeOutValue;
    public Ease easetype;
    SpriteRenderer sp;
    bool fade;

	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeToActivate);
        sp.DOFade(fadeOutValue, fadeOutime).SetEase(easetype).OnComplete(() =>
         {
             Destroy(gameObject); 
         });
    }
}
