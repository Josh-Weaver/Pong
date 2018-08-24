using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddleMovement : MonoBehaviour {

    [SerializeField]
    float MoveSpeed = 3;

    Transform paddlePosition;
    public Transform ballPosition;

    // Use this for initialization
    void Start()
    {
        MoveSpeed = Settings.Player2MoveSpeed;

        paddlePosition = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalController.Playing)
        {
            if (ballPosition != null)
            {
                Move(ballPosition.transform.position.y);
            }
        }
    }

    void Move(float ballVerticalPosition)
    {
        Vector3 targetPosition = new Vector3(paddlePosition.position.x, ballVerticalPosition, paddlePosition.position.z);
        paddlePosition.position = Vector3.MoveTowards(paddlePosition.position, targetPosition, MoveSpeed * Time.deltaTime);
    }

    public void LocateBall(Transform ballTransform)
    {
        ballPosition = ballTransform;
    }
}
