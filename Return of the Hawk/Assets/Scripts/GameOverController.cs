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


    public void QuitButton() {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RetryButton() {
        SceneManager.LoadScene(firstGameScene);
        gameover = false;
    }

    void Start() {
        gameover = false;
        mainCanvas.SetActive(false);
    }

    void Update() {
        mainCanvas.SetActive(gameover);
        scoreDisplay.text = score.ToString();
    }
}
