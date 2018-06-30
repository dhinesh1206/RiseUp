using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour {

    Rigidbody2D rb;
    public float timeToActivate, activationgravityscale,deactivationgravityscale, deActivateTime;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Activate());
       
	}

    public IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        rb.gravityScale = activationgravityscale;
        StartCoroutine(Deactivate());
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(deActivateTime);
        rb.velocity = Vector2.zero;
        rb.gravityScale = deactivationgravityscale;
        
    }
}
