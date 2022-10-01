using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 4f;

    private bool shouldMove;
    private Rigidbody2D rb;
    private CapsuleCollider2D playerCollider;
    private FollowerManager fm;

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

    void OnTriggerExit2D(Collider2D otherCol)
    {
        if(otherCol.gameObject.tag == "House")
        {
            print("Encountered house");
            fm.SpawnFollowers(new Vector2(otherCol.gameObject.transform.position.x - Random.Range(-3f, 0.1f), gameObject.transform.position.y + Random.Range(-0.5f, 0.2f)));
        }
    }
}
