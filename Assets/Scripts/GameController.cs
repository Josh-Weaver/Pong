using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    public GameObject PlayerPaddle;
    public GameObject AIPaddle;
    public GameObject Ball;
    public GameObject[] Scores = new GameObject[2];
    public GameObject EndText;

    public GameObject Canvas;

    private GameObject BallInstance;
    private GameObject Player1PaddleInstance;
    private GameObject Player2PaddleInstance;

    [SerializeField]
    private GameObject GameplayContainer;

    int[] PlayerScores = { 0 , 0 };

	void Start () {
        InstantiatePrefabs();
        InitializeVariables();
    }

    void InstantiatePrefabs()
    {
        Debug.Log("Ball Movespeed: " + Settings.BallMoveSpeed);
        BallInstance = Instantiate(Ball, Constants.BallStartPosition, Quaternion.identity, GameplayContainer.transform);

        Player1PaddleInstance = Instantiate(PlayerPaddle, Constants.Player1StartPosition, Quaternion.identity, GameplayContainer.transform);
        Player1PaddleInstance.GetComponent<PlayerPaddleMovement>().SetPlayerId(0);

        Debug.Log("Multiplayer: " + Settings.Multiplayer);
        if (Settings.Multiplayer)
        {
            Player2PaddleInstance = Instantiate(PlayerPaddle, Constants.Player2StartPosition, Quaternion.identity, GameplayContainer.transform);
            Player2PaddleInstance.GetComponent<PlayerPaddleMovement>().SetPlayerId(1);
        }
        else
        {
            Player2PaddleInstance = Instantiate(AIPaddle, Constants.Player2StartPosition, Quaternion.identity, GameplayContainer.transform);
            Player2PaddleInstance.GetComponent<AIPaddleMovement>().LocateBall(BallInstance.transform);
        }
    }

    void InitializeVariables()
    {
        PlayerScores[0] = Settings.Player1StartingScore;
        PlayerScores[1] = Settings.Player2StartingScore;
        SetScore(0);
        SetScore(1);
    }

    void Update () {
        
		if(BallInstance == null && GlobalController.Playing)
        {
            SpawnBall();
        }
	}

    void SpawnBall()
    {
        BallInstance = (GameObject) Instantiate(Ball, GameplayContainer.transform);
        if (!Settings.Multiplayer)
        {
            Player2PaddleInstance.GetComponent<AIPaddleMovement>().LocateBall(BallInstance.transform);
        }
    }

    void SetScore(int playerId)
    {
        Scores[playerId].GetComponent<TextMesh>().text = PlayerScores[playerId].ToString();
    }

    void PlayerScored(int playerId)
    {
        PlayerScores[playerId] += 1;
        SetScore(playerId);
        if(PlayerScores[playerId] >= Settings.ScoreToWin)
        {
            GameOver(playerId);
        }
    }

    void GameOver(int playerId)
    {
        GlobalController.EndGame();

        EndText.GetComponent<TextMesh>().text = string.Format("Player {0} Wins!", playerId + 1);
    }


    void OnEnable()
    {
        //Add Event Listeners here if needed
    }

    void OnDisable()
    {
        //Remove Event Listeners here if needed
    }
}
