using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffForceOnContact : MonoBehaviour {

    public ObjectAddForce addForceScript;
    public float thurstValuein,thurstValueOut;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            addForceScript.thrust = thurstValuein;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        addForceScript.thrust = thurstValueOut;
    }
}
