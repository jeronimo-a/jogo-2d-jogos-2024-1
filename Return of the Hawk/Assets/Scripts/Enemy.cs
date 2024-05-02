using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;

    private float health = 20.0f;
    private float damage = 10.0f;
	  private float speed = 1.0f;
    private bool canShoot = true;
    private float timeBetweenShots = 0.5f;
    private float timer = 0.0f;
    private GameObject player;
    private Rigidbody2D rb;

	public void TakeDamage(float damage)
	{
        health -= damage;
	}
    
    public float GetDamage()
    {
        return damage;
    }
    
    public float GetHealth()
    {
        return health;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        player = GameObject.Find("Player");
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
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void Shoot()
    {
        Instantiate(bullet, transform.position - transform.up, transform.rotation);
        bullet.SetActive(true);
        canShoot = false;
    }

    void FixedUpdate()
    {
        AutoMove();
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

        if (player == null)
        {
            StopMoving();
            return;
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                canShoot = true;
                timer = 0.0f;
            }
        }
        
        if (canShoot)
            Shoot();

        AimToPlayer();
    }
}
