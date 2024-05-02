using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    
    private Animator walkAnimation;
    private Animator dieAnimation;
    private GameManager gameManager;
    private float health;
	private float speed = 3.0f;
    private bool canShoot = true;
    private float timeBetweenShots = 0.3f;
    private float timer = 0.0f;
    private Rigidbody2D rb;

    private bool isMoving;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


	public void TakeDamage(float damage)
	{
        gameManager.TakeDamage(damage, "Player");
        health = gameManager.GetPlayerHealth();
	}
    
    void Start()
    {
        walkAnimation = GetComponent<Animator>();
        dieAnimation = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        health = gameManager.GetPlayerHealth();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        isMoving = false;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ){
            // audioManager.PlaySFX(audioManager.walk);
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        walkAnimation.SetFloat("Speed",(Mathf.Abs(horizontalInput)) + (Mathf.Abs(verticalInput)));
        
    
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
        canShoot = false;
        Instantiate(bullet, transform.position - transform.up / 3, transform.rotation);
        bullet.SetActive(true);
        audioManager.PlaySFX(audioManager.shot);
    }

    void FixedUpdate()
    {
        if (health <= 0)
            return;
        
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
            dieAnimation.SetFloat("Health", health);
            // GetComponent<Collider>().enabled = false;
			// Destroy(gameObject);
            return;
        }

        RotateTowardsMouse();

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenShots)
            {
                canShoot = true;
                timer = 0.0f;
            }
        }
        
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && canShoot)
            Shoot();
        
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
        
        // ONLY DAMAGE TEST
        if (Input.GetKeyDown(KeyCode.T))
            TakeDamage(100.0f);
    }
}
