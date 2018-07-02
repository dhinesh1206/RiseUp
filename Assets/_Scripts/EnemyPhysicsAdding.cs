using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysicsAdding : MonoBehaviour {

    public float gravityScale,destroyTime = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(null);
        transform.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
       // Destroy(gameObject, destroyTime);
    }
}
