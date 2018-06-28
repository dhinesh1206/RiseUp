using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSnakeCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            FollowStart.instance.SmallSnakeDeath(gameObject);
        }
    }
}
