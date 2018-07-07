using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowStart : MonoBehaviour {

    public static FollowStart instance;

    public List<GameObject> tail;
    public GameObject[] tailPrefab;
    public List<GameObject> Child;
    public int tailCount,maxTailToShow;
    public float speed;
    public Vector2[] sizeDifference;
    public int index,currentChild;
    public bool testing;

    private void OnEnable()
    {
        EventManager.instance.On_NextLevel += On_NextLevel;
        EventManager.instance.On_Death += On_Death;
        EventManager.instance.On_Reload += On_NextLevel;
    }

    private void OnDisable()
    {
        EventManager.instance.On_NextLevel -= On_NextLevel;
        EventManager.instance.On_Death -= On_Death;
        EventManager.instance.On_Reload -= On_NextLevel;
    }

    private void On_NextLevel()
    {
        AddTails(4);
        StartCoroutine(TunOnChilds());

    }

    private void On_Death()
    {
    }

    IEnumerator TunOnChilds()
    {
        
        yield return new WaitForSeconds(0.5f);
        currentChild = 3;
        foreach (GameObject child in Child)
        {
            child.SetActive(true);
        }
    }

    private void Start()
    {
        currentChild = 3;
        index = Random.Range(0, tailPrefab.Length);
        for (int i=0; i<tailCount; i++)
        {

            GameObject createdObject = Instantiate(tailPrefab[index], transform, false);
            createdObject.transform.localScale = sizeDifference[i];
            createdObject.transform.SetParent(null);
            tail.Add(createdObject);
        }
        tailCount = tail.Count;
        TailCountIndicator.instance.UpdateCount();


        TailAnim();

       // StartCoroutine(AddTail(3));
       //StartCoroutine(Restart(restartTime));
    }

    public void CreateTail()
    {
    }

    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        EventManager.instance.OnDeath();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        return;
        if (tail.Count > 0)
        {
            //tail[0].transform.position = Vector3.MoveTowards( new Vector3(tail[0].transform.position.x, transform.position.y, tail[0].transform.position.z);
            tail[0].transform.position = Vector2.Lerp(tail[0].transform.position, transform.position, speed * Time.deltaTime);
        }

        for (int i = 1; i < tail.Count; i++)
        {
            //tail[i].transform.position = new Vector3(tail[i].transform.position.x,tail[i - 1].transform.GetChild(1).transform.position.y, tail[i].transform.position.z);
            tail[i].transform.position = Vector2.Lerp(tail[i].transform.position, tail[i - 1].transform.GetChild(1).transform.position, speed*Time.deltaTime);

        }
    }

    void EarlyUpdate()
    {

    }

    private void LateUpdate()
    {
        
    }

    public float animCheckTime;
    
    public void TailAnim()
    {
        
        

        if (tail.Count > 0)
            tail[0].transform.DOMove(transform.position, animCheckTime, false).SetEase(Ease.Linear);

        for (int i = 1; i < tail.Count; i++)
             tail[i].transform.DOMove(tail[i - 1].transform.GetChild(1).transform.position, animCheckTime, false).SetEase(Ease.Linear);

        Invoke("TailAnim", animCheckTime);
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
        if (tail.Count == 0 || currentChild == 0)
        {
            if (!testing)
            {
                StartCoroutine(Restart(0));
            }
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
          GameObject createdobject = Instantiate(tailPrefab[index], transform, false);
            createdobject.transform.localScale = sizeDifference[tailCount-1];
          createdobject.transform.SetParent(null);
          tail.Add(createdobject);
          tail[tail.Count-1].transform.position = Vector2.Lerp(tail[tail.Count - 1].transform.position, tail[tail.Count - 2].transform.GetChild(1).transform.position, speed * Time.deltaTime);
          tailCount += 1;
            TailCountIndicator.instance.UpdateCount();
        }
    }

    public void SmallSnakeDeath(GameObject child)
    {
        // Child.Remove(child);
        child.SetActive(false);
        currentChild -= 1;
        if (tail.Count == 0 || currentChild == 0)
        {
            if (!testing)
            {
                StartCoroutine(Restart(0));
            }
        }
    }
}
