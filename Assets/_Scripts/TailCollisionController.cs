using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCollisionController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FollowStart.instance.DetachTail(gameObject);
        }
    }
}
