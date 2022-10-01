using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour
{
    public static FollowerManager instance;

    public List<GameObject> followers;
    public float difficultyPerFollower = 0.2f;

    private Player playerRef;
    private NoteSpawner noteSpawnerRef;
    private GameObject follower;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRef = Player.instance;
        noteSpawnerRef = NoteSpawner.instance;
    }

    public void SpawnFollowers(Vector2 spawnPos)
    {
        int numberOfFollowers = Random.Range(1,4);

        for (int i = 1; i <= numberOfFollowers; i++)
        {
            follower = Instantiate(Resources.Load<GameObject>("Prefabs/Follower"), spawnPos, Quaternion.identity);
            followers.Add(follower);
            noteSpawnerRef.UpdateTimer(-difficultyPerFollower);
        }
        
    }

    public void AwakenFollower(GameObject target)
    {
        followers.Remove(target);
        noteSpawnerRef.UpdateTimer(difficultyPerFollower);
    }
}
