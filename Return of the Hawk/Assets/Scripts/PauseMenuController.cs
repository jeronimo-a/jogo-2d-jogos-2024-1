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


    public void QuitButton() {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void ResumeButton() {
        paused = false;
        mainCanvas.SetActive(false);
    }

    void Start() {
        paused = false;
        mainCanvas.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(pauseKey) || paused) {
            paused = true;
        }
        mainCanvas.SetActive(paused);
        currentScoreDisplay.text = currentScore.ToString();
    }
}
