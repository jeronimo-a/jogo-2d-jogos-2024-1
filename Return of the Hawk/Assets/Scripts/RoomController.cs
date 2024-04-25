using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    Rigidbody2D rbPlayer;
    public bool enemiesKilled = false;
    public bool initialRoom = false;
    public bool finalRoom = false;

    void Start() {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update() {

        bool changeRoom = rbPlayer.position.x >= 3.5;
        changeRoom = changeRoom || rbPlayer.position.x <= -3.5;
        changeRoom = changeRoom || rbPlayer.position.y >= 2.5;
        if (!initialRoom) {
            changeRoom = changeRoom || rbPlayer.position.y <= -2.5;
        }
        changeRoom = changeRoom && enemiesKilled && !finalRoom;

        if (changeRoom) {
            SceneManager.LoadScene(RoomSelector.GetRoom());
        }
    }
}
