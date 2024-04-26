using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4.0f;
    public GameObject player;
    public float health = 20.0f;
    public bool canShoot = true;
    public float timeBetweenShots = 0.5f;
    
    public GameObject bullet;
    
    private float angle;
    private float timer = 0;
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
        Vector3 rotation = player.transform.position - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        bullet.SetActive(true);
        canShoot = false;
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

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                canShoot = true;
                timer = 0;
            }
        }
        
        if (canShoot)
            Shoot();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
            health -= 10;
    }
}
