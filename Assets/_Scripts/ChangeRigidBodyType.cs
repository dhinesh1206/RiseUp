using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRigidBodyType : MonoBehaviour {
    
    Rigidbody2D rb;
    public RigidbodyType2D typeTochange;
    public float timeToActivate,gravityScale,mass;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Activate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        rb.bodyType = typeTochange;
        if(typeTochange == RigidbodyType2D.Dynamic)
        {
            rb.gravityScale = gravityScale;
            rb.mass = mass;
        }
    }
}
