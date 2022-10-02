using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject noteTimer;
    private NoteSpawner noteSpawner;
    private Player playerRef;
    private FollowerManager followerManager;

    public bool gameOver;
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        noteSpawner = NoteSpawner.instance;
        playerRef = Player.instance;
        followerManager = FollowerManager.instance;

        playerRef.SetShouldMove(true);
    }

    
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                    {
                        VerifyHit("q");
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        VerifyHit("w");
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        VerifyHit("e");
                    }
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        VerifyHit("r");
                    }
        }else
        {
            noteTimer.SetActive(false);
        }
        
    }

    void VerifyHit(string keyCode)
    {

        if (noteSpawner.GetSpawnedNote() == keyCode)
        {
            // print("Correct!");
        }else
        {
            RegisterMiss();
        }
        noteSpawner.ClearNote();
    }

    public void RegisterMiss()
    {
        if(!gameOver)
        {
            //Choose random follower from the crowd and stack them with a mistake
            //Number of choices increases with followers
            if (followerManager.followers.Count >= 1)
            {
                int counter = Mathf.FloorToInt(followerManager.followers.Count/2);
        
                for (int i = 1; i <= counter; i++)
                {
                    int randomFollower  = Random.Range(1,followerManager.followers.Count);
                    followerManager.followers[randomFollower].gameObject.GetComponent<Follower>().Awaken();
                }
            }  
        }
    }
}
