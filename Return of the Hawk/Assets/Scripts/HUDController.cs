using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI armorDisplay;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI bulletsLoadedDisplay;
    public TextMeshProUGUI bulletsAvailableDisplay;
    public GameObject scoreParent;
    private Color baseTextColor;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        baseTextColor = armorDisplay.color;
    }

    void Update() {

        int roundedArmor = (int) Mathf.Round(gameManager.GetPlayerArmor());
        int roundedHealthPercentage = (int) Mathf.Round(gameManager.GetPlayerHealth() / gameManager.GetPlayerMaxHealth() * 100);

        scoreDisplay.text = gameManager.GetScore().ToString();
        armorDisplay.text = roundedArmor.ToString();
        healthDisplay.text = roundedHealthPercentage.ToString() + "%";
        bulletsLoadedDisplay.text = gameManager.GetPlayerMagazineAmmo().ToString();
        bulletsAvailableDisplay.text = gameManager.GetPlayerReserveAmmo().ToString();
        scoreParent.SetActive(!gameManager.IsPaused() && !gameManager.IsGameOver());

        Color newColor;
        float colorGB;

        if (roundedArmor <= 200 && roundedArmor >= 0) {
            colorGB = gameManager.GetPlayerArmor() / gameManager.GetPlayerArmorIncrement() * baseTextColor.r;
            newColor.r = baseTextColor.r;
            newColor.g = colorGB;
            newColor.b = colorGB;
            newColor.a = baseTextColor.a;
            Debug.Log(newColor.r);
            Debug.Log(colorGB);
            armorDisplay.color = newColor;
        } else {
            armorDisplay.color = baseTextColor;
        }
        
        colorGB = (float) roundedHealthPercentage / 100.0f * baseTextColor.r;
        newColor.r = baseTextColor.r;
        newColor.g = colorGB;
        newColor.b = colorGB;
        newColor.a = baseTextColor.a;
        Debug.Log(newColor.r);
        Debug.Log(colorGB);
        healthDisplay.color = newColor;
    }
}
