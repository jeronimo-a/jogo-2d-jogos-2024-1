using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float playerHealth = 1000.0f;
    private int playerMagazineAmmo = 12;
    private int playerReserveAmmo = 24;
    private float enemyHealth = 20.0f;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
    
    public int GetPlayerMagazineAmmo()
    {
        return playerMagazineAmmo;
    }
    
    public int GetPlayerReserveAmmo()
    {
        return playerReserveAmmo;
    }
    
    public int GetPlayerTotalAmmo()
    {
        return playerMagazineAmmo + playerReserveAmmo;
    }
    
    public float GetEnemyHealth()
    {
        return enemyHealth;
    }
    
    public void TakeDamage(float damage, string source)
    {
        if (source == "Player")
        {
            playerHealth -= damage;
        } else if (source == "Enemy")
        {
            enemyHealth -= damage;
        }
    }
    
    public void PickUpAmmo(int ammo = 12)
    {
        playerReserveAmmo += ammo;
    }
    
    public void Reload()
    {
        if (playerReserveAmmo > 0)
        {
            int ammoNeeded = 12 - playerMagazineAmmo;
            if (playerReserveAmmo >= ammoNeeded)
            {
                playerReserveAmmo -= ammoNeeded;
                playerMagazineAmmo = 12;
                return;
            }
            playerMagazineAmmo += playerReserveAmmo;
            playerReserveAmmo = 0;
        }
    }
}
