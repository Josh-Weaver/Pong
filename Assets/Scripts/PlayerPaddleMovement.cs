using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleMovement : MonoBehaviour {

    [SerializeField]
    float MoveSpeed = 3;

    Transform paddlePosition;

    public int PlayerId = 0;

	// Use this for initialization
	void Start () {
        MoveSpeed = Settings.Player1MoveSpeed;

        paddlePosition = gameObject.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GlobalController.Playing)
        {
            var verticalMovement = Time.deltaTime * 3.0f;
            if (PlayerId == 0)
            {
                verticalMovement *= Input.GetAxis("Player1_Vertical");
            } else if (PlayerId == 1)
            {
                verticalMovement *= Input.GetAxis("Player2_Vertical");
            }

            Move(verticalMovement * MoveSpeed);
        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerId == 0)
        {
            Debug.Log("PLAYER TOGGLED PAUSED!");
            if (GlobalController.Playing)
            {
                GlobalController.PauseGame();
            }
            
            else {
                GlobalController.ResumeGame();
            }
        }
    }

    void Move(float verticalMovement)
    {
        paddlePosition.Translate(0, verticalMovement, 0);
    }

    public void SetPlayerId(int playerId)
    {
        PlayerId = playerId;
    }
}
