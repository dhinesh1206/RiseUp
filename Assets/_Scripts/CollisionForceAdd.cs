using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForceAdd : MonoBehaviour {

    public Vector2 forceAngle;
    public bool emptyPreviousVelocity= false;
    public float forceMultiplier;
    public string tagName;
    private GameObject collidedObject;

    private void Update()
    {
        if(collidedObject)
        {
            collidedObject.GetComponent<Rigidbody2D>().AddForce(forceAngle * forceMultiplier );
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            if (emptyPreviousVelocity)
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collidedObject = collision.gameObject;
            print(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
        }
    }
}
