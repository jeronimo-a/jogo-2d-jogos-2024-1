using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public string mainMenuScene;
    public string firstGameScene;
    public bool gameover = false;
    public GameObject mainCanvas;
    public TextMeshProUGUI scoreDisplay;
    public int score;
    private GameManager gameManager;
    private GameObject gameManagerObject;


    public void QuitButton() {
        SceneManager.LoadScene(mainMenuScene);
        Destroy(gameManagerObject);
    }

    public void RetryButton() {
        SceneManager.LoadScene(firstGameScene);
        gameover = false;
        Destroy(gameManagerObject);
    }

    void Start() {
        gameover = false;
        mainCanvas.SetActive(false);
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update() {
        mainCanvas.SetActive(gameover);
        scoreDisplay.text = score.ToString();
        gameover = gameManager.IsGameOver();
    }
}
