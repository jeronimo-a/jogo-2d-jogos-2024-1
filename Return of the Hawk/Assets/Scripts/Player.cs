using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float health = 1000.0f;
    public float bulletSpeed = 10.0f;
    public bool canShoot = true;
    public float timeBetweenShots = 0.5f;
    
    public GameObject bullet;
    public Animator walk_animation;
    public Animator die_animation;

    private float timer = 0;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        walk_animation.SetFloat("Speed",(Mathf.Abs(horizontalInput)) + (Mathf.Abs(verticalInput)));
    }
    
    void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void Shoot()
    {
        Instantiate(bullet, transform.position - transform.up / 3, transform.rotation);
        bullet.SetActive(true);
        canShoot = false;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Reload()
    {
        return;
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Option"))
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Option");

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }

        }
    }

    void Update()
    {
        if (health <= 0)
		{
            die_animation.SetFloat("Health",health);
            // this.GetComponent<Collider>().enabled = false;
			Destroy(gameObject);
		}

        RotateTowardsMouse();

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                canShoot = true;
                timer = 0;
            }
        }
        
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && canShoot)
            Shoot();
        
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
        
        // ONLY DAMAGE TEST
        // if (Input.GetKeyDown(KeyCode.T))
        //     health -= 10;
    }
}
