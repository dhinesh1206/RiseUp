using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChangeonCollision : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        rb.gravityScale = 1;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //rb.gravityScale = 0;
    }
}
