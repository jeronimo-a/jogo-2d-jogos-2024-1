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

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        scoreDisplay.text = gameManager.GetScore().ToString();
        armorDisplay.text = gameManager.GetRoundedArmor().ToString();
        healthDisplay.text = gameManager.GetRoundedHealthPercentage().ToString() + "%";
        bulletsLoadedDisplay.text = gameManager.GetBulletsLoaded().ToString();
        bulletsAvailableDisplay.text = gameManager.GetBulletsAvailable().ToString();
        scoreParent.SetActive(!gameManager.IsPaused() && !gameManager.IsGameOver());
    }
}
