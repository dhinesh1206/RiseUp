using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePickup : MonoBehaviour {

    public int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FollowStart.instance.AddTails(count);
            Destroy(gameObject);
        }
    }
}
