using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float health = 100.0f;

    public Animator animator;

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
        animator.SetFloat("Speed",(Mathf.Abs(horizontalInput)) + (Mathf.Abs(verticalInput)) );
    }
    
    void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = -direction;
    }
    
    void Shoot()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * 10;
            bullet.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Move();
        RotateTowardsMouse();
    }

    void Reload()
    {
        ObjectPool.SharedInstance.pooledObjects.ForEach(obj => obj.SetActive(false));;
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            Shoot();
        
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
        
        // ONLY DAMAGE TEST
        if (Input.GetKeyDown(KeyCode.T))
            health -= 10;
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
