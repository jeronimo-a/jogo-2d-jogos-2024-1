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

    void Start() {
        mainCanvas.SetActive(choiceRoom);
        roomController.choiceMade = !choiceRoom;
    }

    public void LeftButton() {
        mainCanvas.SetActive(false);
        roomController.choiceMade = true;
    }

    public void RightButton() {
        mainCanvas.SetActive(false);
        roomController.choiceMade = true;
    }
}
