using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float speed;
    public int mistakeTollerance = 3;
    public Animator animator;
    public List<GameObject> children;
    
    private Player playerRef;
    private FollowerManager followerManager;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] float minDistanceToFollow;
    [SerializeField] bool isAwake = false;

    void Start()
    {
        playerRef = Player.instance;
        followerManager = FollowerManager.instance;
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        minDistanceToFollow = Random.Range(2f, 7f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var step = speed * Time.fixedDeltaTime;
        if(!isAwake)
        {
            
            var target = (Vector2)playerRef.gameObject.transform.position;
            Vector2 dir = (target - (Vector2)rb.transform.position).normalized;

            if(Vector2.Distance(target, (Vector2)rb.transform.position) > minDistanceToFollow)
            {
                rb.AddForce(dir * step);
            }
        }else
        {
            rb.AddForce(Vector2.left * step );
        }

        if(!isAwake)
        {
            FacePlayer();
        }else
        {
            gameObject.transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
        }
        
    }

    public void Awaken()
    {
        mistakeTollerance--;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.red, 0.4f);
        
        children.RemoveAt(children.Count - 1);
        

        if(mistakeTollerance <= 0)
        {
            followerManager.AwakenFollower(gameObject);
            isAwake = true;
            animator.SetTrigger("hasAwakened");
        }
    }

    void FacePlayer()
    {
        if(transform.position.x > playerRef.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
        }else
        {
            gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        }
    }
}
