using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLerp : MonoBehaviour {

    public float timeToActivate,speed;
    public Vector3 endPosition;
    public bool idle = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(Activate());
	}
	
	// Update is called once per frame
	void Update () {
        if (idle == false)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, speed * Time.deltaTime);
        }
	}

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        idle = false;
    }
}
