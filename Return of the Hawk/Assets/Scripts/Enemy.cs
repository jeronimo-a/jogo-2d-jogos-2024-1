using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4.0f;
    public GameObject player;
    public float health = 20.0f;
    
    private float angle;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
    }
    
    void StopMoving()
    {
        rb.velocity = Vector2.zero;
        rb.simulated = false;
        transform.rotation = Quaternion.identity;
    }

    void AutoMove()
    {
        Vector2 movement = (player.transform.position - transform.position).normalized * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void AimToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        AutoMove();
        AimToPlayer();
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

        if (player == null)
            StopMoving();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            collision.gameObject.SetActive(false);
        }
    }
}
