using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    public Rigidbody2D player;
    public bool enemiesKilled = false;
    public bool initialRoom;

    // Update is called once per frame
    void Update() {

        bool changeRoom = player.position.x >= 3.5;
        changeRoom = changeRoom || player.position.x <= -3.5;
        changeRoom = changeRoom || player.position.y >= 2.5;
        if (!initialRoom) {
            changeRoom = changeRoom || player.position.y <= -2.5;
        }
        changeRoom = changeRoom && enemiesKilled;

        if (changeRoom) {
            SceneManager.LoadScene(RoomSelector.GetRoom());
        }
    }
}
