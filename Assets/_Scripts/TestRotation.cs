using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestRotation : MonoBehaviour {
	public float speed;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime*speed);
	}
}
