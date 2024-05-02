using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuController : MonoBehaviour {

    public string mainMenuScene;
    public KeyCode pauseKey = KeyCode.Escape;
    public bool paused = false;
    public GameObject mainCanvas;
    public TextMeshProUGUI currentScoreDisplay;
    public int currentScore;
    private GameManager gameManager;


    public void QuitButton() {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void ResumeButton() {
        paused = false;
        mainCanvas.SetActive(false);
        gameManager.PauseGame(false);
    }

    void Start() {
        paused = false;
        mainCanvas.SetActive(false);
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
    }

    void Update() {
        if (Input.GetKeyDown(pauseKey) || paused) {
            gameManager.PauseGame(true);
            paused = true;
        }
        mainCanvas.SetActive(paused);
        currentScoreDisplay.text = currentScore.ToString();
    }
}
