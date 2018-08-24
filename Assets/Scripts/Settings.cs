using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Settings {

    public static bool Multiplayer { get; set; } = false;
    public static float Player1MoveSpeed { get; set; } = 3f;
    public static float Player2MoveSpeed { get; set; } = 3f;
    public static float BallMoveSpeed { get; set; } = 5f;
    public static float BallSpeedIncrement { get; set; } = .2f;
    public static int ScoreToWin { get; set; } = 11;
    public static int Player1StartingScore { get; set; } = 0;
    public static int Player2StartingScore { get; set; } = 0;

    public static KeyCode Player1UpMovement = KeyCode.W;
    public static KeyCode Player1DownMovement = KeyCode.S;
    public static KeyCode Player2UpMovement = KeyCode.UpArrow;
    public static KeyCode Player2DownMovement = KeyCode.DownArrow;

}
