using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float speed = 10.0f;
    private float damage = 10.0f;
    
    void FixedUpdate()
    {
        transform.position -= transform.up * speed * Time.fixedDeltaTime;
    }
    
    public void UpdateDamage()
    {
        damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().GetDamage();
    }
    
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        
        Destroy(gameObject);
    }
}
