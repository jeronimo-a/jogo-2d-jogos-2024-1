using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    
    void FixedUpdate()
    {
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
    
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= 10;
            gameObject.SetActive(false);
        }
		else if (collision.gameObject.CompareTag("Player"))
	    {
            collision.gameObject.GetComponent<Player>().health -= 10;
            gameObject.SetActive(false);
        }
    }
}
