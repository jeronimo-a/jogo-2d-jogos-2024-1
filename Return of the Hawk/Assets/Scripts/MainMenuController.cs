using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour {

    public string firstGameScene;
    public string highscore;
    public TextMeshProUGUI highscoreNumberText;
    public string Tutorial;
    public string Settings;

    void Start() {
        highscoreNumberText.text = highscore.ToString();
    }

    public void PlayButton() {
        SceneManager.LoadScene(firstGameScene);
        Debug.Log("Play Button Pressed");
    }

    public void TutorialButton() {
        SceneManager.LoadScene(Tutorial);
        Debug.Log("Tutorial Button Pressed");
    }

    public void SettingsButton() {
        SceneManager.LoadScene(Settings);
        Debug.Log("Settings Button Pressed");
    }
    public void QuitButton() {
        Debug.Log("Quit Button Pressed");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBGL
            Application.OpenURL("about:blank");
        #else
            Application.Quit();
        #endif
    }
}
