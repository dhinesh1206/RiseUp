using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickObjects : MonoBehaviour {

    public string tagName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == tagName)
        {

            //collision.gameObject.GetComponent<Collider2D>().sharedMaterial = null;
			//collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			Destroy(collision.transform.GetComponent<Rigidbody2D>());
            collision.gameObject.transform.SetParent(transform);
        }
    }
}
