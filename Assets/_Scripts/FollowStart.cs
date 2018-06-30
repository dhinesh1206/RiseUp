using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class FollowStart : MonoBehaviour {

    public static FollowStart instance;

    public List<GameObject> tail;
    public List<GameObject> Child;
    public GameObject head;
    public float speed, restartTime;

    private void Start()
    {
        //StartCoroutine(Restart(restartTime));
    }

    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (tail.Count == 0 || Child.Count == 0)
        {
            StartCoroutine(Restart(1));
        }

        if (tail.Count > 0)
        {
            tail[0].transform.position = Vector2.Lerp(tail[0].transform.position, transform.position, speed * Time.deltaTime);
        }

        for (int i = 1; i < tail.Count; i++)
        {
            tail[i].transform.position = Vector2.Lerp(tail[i].transform.position, tail[i - 1].transform.GetChild(1).transform.position, speed*Time.deltaTime);
        }
    }

    public void DetachTail(GameObject tailtobedetached)
    {
        //int indextodetach = tail.IndexOf(tailtobedetached.transform.parent.gameObject);
        //for (int i = tail.Count-1; i >= indextodetach; i--)
        //{
        //    tail[i].GetComponentInChildren<Collider2D>().enabled = false;
        //    tail[i].AddComponent<Rigidbody2D>();
        //    tail.Remove(tail[i]);
        //}
        GameObject TailDeath = tail[tail.Count - 1];
        tail.Remove(TailDeath);
        Destroy(TailDeath);
    }

    public void SmallSnakeDeath(GameObject child)
    {
        Child.Remove(child);
        Destroy(child);
    }
}
