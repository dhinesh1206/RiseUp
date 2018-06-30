using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    Rigidbody2D rb;
    public float velocity, timeToActivate;
    public ForceMode2D forcemode;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Activate());
    }

    public IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        
            rb.AddTorque(velocity, forcemode);
        

    }

   
}
