using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [SerializeField]
    float MoveSpeed = 5;
    [SerializeField]
    float SpeedIncrement = .2f;
    float MaxAngle = 0.8f;
    float MinAngle = 0.3f;

    [SerializeField]
    float PaddleSize = 5;

    float MaxBounceAngle = .75f;

    Vector3 MovementDirection;

    Transform ballTransform;

	// Use this for initialization
	void Start () {
        MoveSpeed = Settings.BallMoveSpeed;
        SpeedIncrement = Settings.BallSpeedIncrement;
        ballTransform = gameObject.transform;
        Vector3 targetPosition = new Vector3(Random.Range(-13, 13), Random.Range(-6, 6), 0);
        
        MovementDirection = RestrictMovement(targetPosition.normalized);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GlobalController.Playing)
        {
            Move();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "AI")
        {
            MoveSpeed += SpeedIncrement;

            //Get how far away from the center of the paddle the ball hit
            //0 when it hits the center
            //PaddleSize / 2 when it hits the edge
            //Adjusts the angle of return based on where it hit on the paddle
            //If it hit in the center, reflect directly back
            //If it hit the edge, use the maxiumum bounce angle
            float localizedY = collision.contacts[0].point.y - collision.collider.transform.position.y;
            float normalizedY = localizedY / (PaddleSize / 2);
            float bounceAngle = normalizedY * MaxBounceAngle;

            MovementDirection = new Vector3(-1 * MovementDirection.x, bounceAngle, 0);
        }

        if (collision.collider.tag == "Wall")
        {
            MovementDirection = Vector3.Reflect(MovementDirection, collision.contacts[0].normal);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }

    void Move()
    {
        ballTransform.position += MovementDirection * MoveSpeed * Time.deltaTime;
    }

    //Restricts the movement to within the min and max angles specified
    //i.e. If the movement is (0,1,0), it changes it to (MinAngle, MaxAngle, 0)
    Vector3 RestrictMovement(Vector3 movement)
    {

        if (Mathf.Abs(movement.x) == 1 && movement.y == 0)
        {
            movement.x *= MaxAngle;
            movement.y = MinAngle;
        }
        else if (Mathf.Abs(movement.y) == 1 && movement.x == 0)
        {
            movement.x = MinAngle;
            movement.y *= MaxAngle;
        }

        return movement;
    }
}
