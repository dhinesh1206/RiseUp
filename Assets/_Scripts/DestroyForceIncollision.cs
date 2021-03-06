﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForceIncollision : MonoBehaviour {

    ObjectAddForce objectAddforce;

	// Use this for initialization
	void Start () {

        objectAddforce = GetComponent<ObjectAddForce>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		
        if(collision.gameObject.tag == "Player")
        {
            objectAddforce.idle = true;

        }
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			objectAddforce.idle = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.8f;
		}
	}


}
