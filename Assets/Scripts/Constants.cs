using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    public enum Scenes {
        MainMenu = 0,
        Gameplay = 1
    };

    public static Vector3 Player1StartPosition = new Vector3(-13, 0, 0);
    public static Vector3 Player2StartPosition = new Vector3(13, 0, 0);
    public static Vector3 BallStartPosition = Vector3.zero;
}
