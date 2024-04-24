using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {

    public Rigidbody2D player;
    public bool enemiesKilled = false;
    public bool initialRoom;
    public string levelRoom1;
    public string levelRoom2;
    public string levelRoom3;
    public string levelRoom4;
    public string levelRoom5;
    public string levelFinalRoom;

    List<string> levelRooms;

    void Start() {
        levelRooms = new List<string>();
        levelRooms.Add(levelRoom1);
        levelRooms.Add(levelRoom2);
        levelRooms.Add(levelRoom3);
        levelRooms.Add(levelRoom4);
        levelRooms.Add(levelRoom5);
        levelRooms.Shuffle();
    }

    // Update is called once per frame
    void Update() {

        bool changeRoom = player.position.x >= 3.5;
        changeRoom = changeRoom || player.position.x <= -3.5;
        changeRoom = changeRoom || player.position.y >= 2.5;
        changeRoom = changeRoom || player.position.y <= -2.5;
        changeRoom = changeRoom && enemiesKilled;

        if (changeRoom) {
            SceneManager.LoadScene(Pop(levelRooms));
        }
    }

    static string Pop(List<string> list) {

        if (list.Count == 0) {
            throw new InvalidOperationException("A lista está vazia.");
        }

        string ultimoElemento = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return ultimoElemento;
    }
}
