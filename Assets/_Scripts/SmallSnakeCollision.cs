﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSnakeCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Sticky"|| collision.gameObject.tag == "Force")
        {
            FollowStart.instance.SmallSnakeDeath(gameObject);
        }
    }
}
