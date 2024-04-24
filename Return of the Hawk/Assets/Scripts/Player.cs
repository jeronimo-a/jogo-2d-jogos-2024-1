using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(1, 0);
        rb.gravityScale = 0;
        rb.angularDrag = 0;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }
}
