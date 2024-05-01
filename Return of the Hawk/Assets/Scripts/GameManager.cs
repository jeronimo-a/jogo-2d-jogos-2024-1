using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float playerHealth = 1000.0f;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
    
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }
}
