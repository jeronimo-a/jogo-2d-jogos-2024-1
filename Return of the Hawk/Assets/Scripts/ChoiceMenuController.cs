using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceMenuController : MonoBehaviour {

    public GameObject mainCanvas;
    public TextMeshProUGUI currentScoreDisplay;
    public int currentScore;
    public bool choiceRoom;

    void Start() {
        mainCanvas.SetActive(choiceRoom);        
    }

    void Update() {
        
    }

    public void LeftButton() {
        mainCanvas.SetActive(false);
    }

    public void RightButton() {
        mainCanvas.SetActive(false);
    }
}
