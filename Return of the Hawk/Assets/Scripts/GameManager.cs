using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private float playerMaxHealth = 500.0f;
    private float playerArmor = 0.0f;
    private float playerHealth = playerMaxHealth;
    private float playerDamage = 10.0f;
    private int playerMagazineAmmo = 12;
    private int playerReserveAmmo = 24;
    private float enemyMaxHealth = 20.0f;
    private float enemyHealth = 50.0f;
    private float enemyDamage = 20.0f;
    private bool gameOver = false;
    private bool paused = false;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame(bool pause)
    {
        paused = pause;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void ResetPlayerHealth()
    {
        playerHealth = playerMaxHealth;
        Debug.Log("curou");
    }

    public void IncrementPlayerArmor()
    {
        playerArmor += 100;
        Debug.Log("armor");
    }
    
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
    
    public void HealPlayer(float health)
    {
        playerHealth += health;
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }
    
    public float GetPlayerDamage()
    {
        return playerDamage;
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
    
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
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
    
    public float GetEnemyHealth()
    {
        return enemyHealth;
    }
    
    public float GetEnemyDamage()
    {
        return enemyDamage;
    }
    
    public void ReplayabilityMultiplier()
    {
        playerMaxHealth *= 1.2f;
        playerDamage *= 1.2f;
        enemyMaxHealth *= 1.1f;
        enemyDamage *= 1.1f;
        GameObject.FindGameObjectWithTag("EnemyBullet").GetComponent<BulletEnemy>().UpdateDamage();
        GameObject.FindGameObjectWithTag("PlayerBullet").GetComponent<BulletPlayer>().UpdateDamage();
    }

    void Update()
    {
        if (playerHealth <= 0)
            gameOver = true;
    }
}
