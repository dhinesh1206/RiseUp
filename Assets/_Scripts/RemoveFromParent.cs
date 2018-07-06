using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromParent : MonoBehaviour {

	public float timeToActivate ;

	// Use this for initialization
	void Start () {
		StartCoroutine (Detach());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Detach ()
	{
		yield return new WaitForSeconds (timeToActivate);
		transform.SetParent (null);
	}

}
