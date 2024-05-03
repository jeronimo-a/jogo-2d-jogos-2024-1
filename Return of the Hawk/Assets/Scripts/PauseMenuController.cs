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
    private GameManager gameManager;
    private GameObject gameManagerObject;


    public void QuitButton() {
        SceneManager.LoadScene(mainMenuScene);
        Destroy(gameManagerObject);
    }

    public void ResumeButton() {
        paused = false;
        mainCanvas.SetActive(false);
        gameManager.PauseGame(false);
    }

    void Start() {
        paused = false;
        mainCanvas.SetActive(false);
        gameManagerObject = GameObject.FindGameObjectsWithTag("GameManager")[0];
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update() {
        if (Input.GetKeyDown(pauseKey) || paused) {
            gameManager.PauseGame(true);
            paused = true;
        }
        mainCanvas.SetActive(paused);
        currentScoreDisplay.text = gameManager.GetScore().ToString();
    }
}
