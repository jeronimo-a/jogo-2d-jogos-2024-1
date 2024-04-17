using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public string firstGameScene;

    public void PlayButton() {
        SceneManager.LoadScene(firstGameScene);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
