using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour {

    public string firstGameScene;
    public string highscore;
    public TextMeshProUGUI highscoreNumberText;

    void Start() {
        highscoreNumberText.text = highscore.ToString();
    }

    public void PlayButton() {
        SceneManager.LoadScene(firstGameScene);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
