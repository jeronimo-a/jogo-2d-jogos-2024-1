using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceMenuController : MonoBehaviour {

    public GameObject mainCanvas;
    public TextMeshProUGUI currentScoreDisplay;
    public int currentScore;
    public bool choiceRoom;
    public RoomController roomController;
    private GameManager gameManager;

    void Start() {
        mainCanvas.SetActive(choiceRoom);
        roomController.choiceMade = !choiceRoom;
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
        gameManager.PauseGame(choiceRoom);
    }

    public void LeftButton() {
        mainCanvas.SetActive(false);
        roomController.choiceMade = true;
        gameManager.ResetPlayerHealth();
        gameManager.PauseGame(false);
    }

    public void RightButton() {
        mainCanvas.SetActive(false);
        roomController.choiceMade = true;
        gameManager.IncrementPlayerArmor();
        gameManager.PauseGame(false);
    }
}
