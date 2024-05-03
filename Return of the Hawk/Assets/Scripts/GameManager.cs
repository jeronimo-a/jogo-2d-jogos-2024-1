using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public float playerMaxHealth = 500.0f;
    static public float playerStartingArmor = 200.0f;
    static public int playerArmorIncrement = 200;
    static public float playerBaseDamage = 10.0f;
    static public int playerMagazineSize = 12;
    static public int playerAmmoReserve = 24;
    static public float enemyMaxHealth = 20.0f;
    static public float enemyBaseDamage = 20.0f;

    private float playerArmor = playerStartingArmor;
    private float playerHealth = playerMaxHealth;
    private float playerDamage = playerBaseDamage;
    private int playerMagazineAmmo = playerMagazineSize;
    private int playerReserveAmmo = playerAmmoReserve;
    private float enemyHealth = enemyMaxHealth;
    private float enemyDamage = enemyBaseDamage;
    private bool gameOver = false;
    private bool paused = false;
    private int score = 0;
    
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
    }

    public void IncrementPlayerArmor()
    {
        playerArmor += playerArmorIncrement;
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

    public int GetScore() {
        return score;
    }

    public int GetRoundedArmor() {
        return (int) Mathf.Round(playerArmor);
    }

    public int GetRoundedHealthPercentage() {
        return (int) Mathf.Round(playerHealth / playerMaxHealth * 100);
    }

    public int GetBulletsLoaded() {
        return playerMagazineAmmo;
    }

    public int GetBulletsAvailable() {
        return playerReserveAmmo;
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
        if (playerArmor >= damage) {
            playerArmor -= (int) damage;
            damage = 0;
        } else if (playerArmor >= 0) {
            damage -= playerArmor;
            playerArmor = 0;
        }
        playerHealth -= damage;
        if (playerHealth < 0)
            playerHealth = 0;
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
