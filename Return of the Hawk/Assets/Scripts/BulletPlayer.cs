using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private float speed = 10.0f;
    private float damage = 10.0f;
    
    void FixedUpdate()
    {
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
    
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            gameObject.SetActive(false);
        }

        Destroy(gameObject);
    }
}
