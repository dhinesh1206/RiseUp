using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAddForce : MonoBehaviour {
    Rigidbody2D rb;
    public float timeToActivate,thrust;
    public Vector2 forceAngle;
    public bool idle = true;
	
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Activate());
	}
	
	void Update ()
    {
        if (!idle)
            rb.AddForce(forceAngle * thrust*Time.deltaTime);
	}

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        idle = false;
    }
}
