using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSelector : MonoBehaviour {

    public string levelRoom1;
    public string levelRoom2;
    public string levelRoom3;
    public string levelRoom4;
    public string levelRoom5;
    public string levelFinalRoom;
    static string _levelFinalRoom;
    public static int numberOfRoomsToPlay = 3;

    public static List<string> levelRooms;

    void Start() {
        levelRooms = new List<string>();
        _levelFinalRoom = levelFinalRoom;
        levelRooms.Add(levelRoom1);
        levelRooms.Add(levelRoom2);
        levelRooms.Add(levelRoom3);
        levelRooms.Add(levelRoom4);
        levelRooms.Add(levelRoom5);
        levelRooms.Shuffle();
    }

    public static string GetRoom() {
        if (levelRooms.Count == (5 - numberOfRoomsToPlay)) {
            return _levelFinalRoom;
        }
        return levelRooms.Pop();
    }
}
