using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public bool canMove = true;

    public LayerMask collisionLayer;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionLayer = LayerMask.GetMask("Wall");
    }

    
    void Update()
    {
        
        if(canMove)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            // Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            // rb.velocity = movement * speed;
    
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.layer == collisionLayer )
    //     {
    //         rb.MovePosition(rb.position - movement * speed *  Time.fixedDeltaTime);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            rb.MovePosition(rb.position - movement * speed *  Time.fixedDeltaTime);
        }
    }
}
