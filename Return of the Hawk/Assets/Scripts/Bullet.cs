using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
    }
}
