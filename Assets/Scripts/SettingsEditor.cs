using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsEditor : MonoBehaviour {

    public Toggle Multiplayer;
    public InputField Player1MoveSpeed;
    public InputField Player2MoveSpeed;
    public InputField BallMoveSpeed;
    public InputField BallSpeedIncrement;
    public InputField ScoreToWin;
    public InputField Player1StartingScore;
    public InputField Player2StartingScore;

    //Initialize InputField Placeholder values
    void Start()
    {
        Multiplayer.isOn = Settings.Multiplayer;
        Player1MoveSpeed.text = Settings.Player1MoveSpeed.ToString();
        Player2MoveSpeed.text = Settings.Player2MoveSpeed.ToString();
        BallMoveSpeed.text = Settings.BallMoveSpeed.ToString();
        BallSpeedIncrement.text = Settings.BallSpeedIncrement.ToString();
        ScoreToWin.text = Settings.ScoreToWin.ToString();
        Player1StartingScore.text = Settings.Player1StartingScore.ToString();
        Player2StartingScore.text = Settings.Player2StartingScore.ToString();
    }

    public void SetMultiplayer()
    {
        Debug.Log("Multiplayer is on: " + Multiplayer.isOn);
        Settings.Multiplayer = Multiplayer.isOn;
    }

    public void SetPlayer1MoveSpeed()
    {
        Debug.Log("Text field value: " + Player1MoveSpeed.text);
        Settings.Player1MoveSpeed = float.Parse(Player1MoveSpeed.text);
    }

    public void SetPlayer2MoveSpeed()
    {
        Debug.Log("Text field value: " + Player2MoveSpeed.text);
        Settings.Player2MoveSpeed = float.Parse(Player2MoveSpeed.text);
    }

    public void SetBallMoveSpeed()
    {
        Debug.Log("Text field value: " + BallMoveSpeed.text);
        Settings.BallMoveSpeed = float.Parse(BallMoveSpeed.text);
    }

    public void SetBallSpeedIncrement()
    {
        Debug.Log("Text field value: " + BallSpeedIncrement.text);
        Settings.BallSpeedIncrement = float.Parse(BallSpeedIncrement.text);
    }

    public void SetScoreToWin()
    {
        Debug.Log("Text field value: " + ScoreToWin.text);
        Settings.ScoreToWin = int.Parse(ScoreToWin.text);
    }

    public void SetPlayer1StartingScore()
    {
        Debug.Log("Text field value: " + Player1StartingScore.text);
        Settings.Player1StartingScore = int.Parse(Player1StartingScore.text);
    }

    public void SetPlayer2StartingScore()
    {
        Debug.Log("Text field value: " + Player2StartingScore.text);
        Settings.Player2StartingScore = int.Parse(Player2StartingScore.text);
    }
}
