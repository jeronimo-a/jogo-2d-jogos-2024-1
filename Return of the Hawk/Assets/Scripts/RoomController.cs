using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    public Rigidbody2D player;

    // Update is called once per frame
    void Update() {
        if (player.position.x >= 4) {
            SceneManager.LoadScene("Level_1_2");
        }
    }
}
