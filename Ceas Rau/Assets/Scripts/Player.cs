using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 4f;

    public bool shouldMove;
    private Rigidbody2D rb;
    private CapsuleCollider2D playerCollider;
    private FollowerManager fm;
    private GameManager gm;
    private NoteSpawner noteSpawner;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        fm = FollowerManager.instance;
        gm = GameManager.instance;
        noteSpawner = NoteSpawner.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            rb.velocity = transform.right * moveSpeed;
        }
    }

    public void SetShouldMove(bool value)
    {
        shouldMove = value;
    }

    void OnTriggerEnter2D(Collider2D otherCol)
    {
        if(otherCol.gameObject.tag == "Finish")
        {
            foreach (var follower in fm.followers)
            {
                follower.GetComponent<Follower>().rb.velocity = Vector2.zero;
                follower.GetComponent<Follower>().speed = 0.5f;
            }
        }
    }
    void OnTriggerExit2D(Collider2D otherCol)
    {
        if(otherCol.gameObject.tag == "House")
        {
            print("Encountered house");
            fm.SpawnFollowers(new Vector2(otherCol.gameObject.transform.position.x - Random.Range(-1f, 0.1f), gameObject.transform.position.y + Random.Range(-0.5f, 0f)));
        }
        if(otherCol.gameObject.tag == "Finish")
        {
            print("Ending Screen");
            shouldMove = false;
            rb.velocity = Vector2.zero;
            noteSpawner.gameObject.SetActive(false);
            
            gm.gameOver = true;
            
        }
    }
}
