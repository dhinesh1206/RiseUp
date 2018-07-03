using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {

    public List<PlayersandchildList> playerCollection;
    public int playerindex,maximumTailsToshow,tailCount,speed;


    void Start ()
    {
        ChoosePlayer();
	}

    public void ChoosePlayer()
    {
        playerindex = Random.Range(0, playerCollection.Count);
        GameObject player = Instantiate(playerCollection[playerindex].playerHead, transform, false);
        GameObject head = player.transform.GetChild(0).gameObject;
        AddCollider(playerCollection[playerindex].headcolliderType, head);
        FollowStart followStart = player.GetComponentInChildren<FollowStart>();
        followStart.tail = playerCollection[playerindex].playerTail;
        followStart.CreateTail();
    }

    public void AddCollider(string colliderType, GameObject objecttoAddCollider)
    {
        switch (colliderType)
        {
            case "Box":
                BoxCollider2D colliderofthehead= objecttoAddCollider.AddComponent<BoxCollider2D>();
               // colliderofthehead.
                break;
            default:
                break;
        }
    }
}

public class PlayersandchildList
{
    public GameObject playerHead;
    public List<GameObject> playerTail;
    public string headcolliderType;
}
