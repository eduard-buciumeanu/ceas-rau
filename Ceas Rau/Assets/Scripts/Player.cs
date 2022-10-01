using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 4f;

    private bool shouldMove;
    private Rigidbody2D rb;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
}
