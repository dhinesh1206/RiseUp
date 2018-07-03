using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGravityChange : MonoBehaviour {

	Rigidbody2D rb;
	public float gravityValue;
	public string tagName;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void  OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == tagName)
		rb.gravityScale = gravityValue;
	}

}
