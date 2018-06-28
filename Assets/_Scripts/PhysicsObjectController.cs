using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjectController : MonoBehaviour {
    Rigidbody2D rb;
    public float maxVelocity;
    public float touchThreshold;
    public float forceMultiplier;
    public FollowStart followStartScript;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(MouseHelper.mouseDelta.x) > touchThreshold || Mathf.Abs(MouseHelper.mouseDelta.y) > touchThreshold)
            {
                rb.velocity = new Vector2(MouseHelper.mouseDelta.x * forceMultiplier, MouseHelper.mouseDelta.y * forceMultiplier);

                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
