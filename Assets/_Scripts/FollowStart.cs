using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class FollowStart : MonoBehaviour {

    public static FollowStart instance;

    public List<GameObject> tail;
    public GameObject tailPrefab, head;
    public List<GameObject> Child;
    public int tailCount,maxTailToShow;
    public float speed;

    private void Start()
    {
        for(int i=0; i<tailCount; i++)
        {
            GameObject createdObject = Instantiate(tailPrefab, transform, false);
            createdObject.transform.SetParent(null);
            tail.Add(createdObject);
        }
        tailCount = tail.Count;
        TailCountIndicator.instance.UpdateCount();
       // StartCoroutine(AddTail(3));
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
        if (tailCount <= maxTailToShow)
        {
            tailCount -= 1;
            TailCountIndicator.instance.UpdateCount();
            GameObject TailDeath = tail[tail.Count - 1];
            tail.Remove(TailDeath);
            Destroy(TailDeath);
            
        }
        else
        {
            tailCount -= 1;
            TailCountIndicator.instance.UpdateCount();
        }
    }

    public void AddTails(int count)
    {
        StartCoroutine(AddTail(count));
    }

    public IEnumerator AddTail(int count)
    {
        for(int i=0; i< count; i++)
        {
            AddTailFunction();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddTailFunction()
    {
        if(tailCount >= maxTailToShow)
        {
            tailCount += 1;
            TailCountIndicator.instance.UpdateCount();
        }
        else
        {
          GameObject createdobject = Instantiate(tailPrefab, transform, false);
          createdobject.transform.SetParent(null);
          tail.Add(createdobject);
          tail[tail.Count-1].transform.position = Vector2.Lerp(tail[tail.Count - 1].transform.position, tail[tail.Count - 2].transform.GetChild(1).transform.position, speed * Time.deltaTime);
          tailCount += 1;
            TailCountIndicator.instance.UpdateCount();
        }
    }

    public void SmallSnakeDeath(GameObject child)
    {
        Child.Remove(child);
        Destroy(child);
    }
}
