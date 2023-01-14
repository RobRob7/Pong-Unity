using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] float _speed;
    Vector2 ballInitialPosition;
    Rigidbody2D ballRigidBody2D;
    Rigidbody2D player1;
    Rigidbody2D player2;
    Vector2 player1Position;
    Vector2 player2Position;

    void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        player1 = GameObject.Find("Player 1").GetComponent<Rigidbody2D>();
        player2 = GameObject.Find("Player 2").GetComponent<Rigidbody2D>();
        player1Position = player1.position;
        player2Position = player2.position;
    }

    // Start is called before the first frame update
    void Start()
    {   
      Invoke("InitialLaunchOfBall", 3);
    }

    // Update is called once per frame
    void Update()
    {

        if(ballRigidBody2D.position.x <= -8.25 || ballRigidBody2D.position.x >= 8.25)
        {
            ResetBall();
            player1.position = player1Position;
            player2.position = player2Position;
        }
    }

    void ResetBall()
    {
        ballRigidBody2D.velocity = new Vector2(0, 0);
        ballInitialPosition = new Vector2(0, 0);
        ballRigidBody2D.MovePosition(ballInitialPosition);
        Invoke("InitialLaunchOfBall", 3);
    }

    void RestartGame()
    {
        ResetBall();
        gameObject.GetComponent<PlayerController>().ResetPlayerPosition();
        Invoke("InitialLaunchOfBall", 1);
    }

    void InitialLaunchOfBall()
    {
        var rnd = new System.Random();
        double randDouble = rnd.NextDouble();

        if(randDouble < 0.25)
        {
            ballRigidBody2D.velocity = new Vector2(Random.Range(5,10), -Random.Range(4,6));
        }
        else if(randDouble >= 0.25 && randDouble < 0.5)
        {
            ballRigidBody2D.velocity = new Vector2(Random.Range(5,10), Random.Range(4,6));
        }
        else if(randDouble >= 0.50 && randDouble < 0.75)
        {
            ballRigidBody2D.velocity = new Vector2(-Random.Range(5,10), Random.Range(4,6));
        }
        else if(randDouble >= 0.75 && randDouble <= 1.0)
        {
            ballRigidBody2D.velocity = new Vector2(-Random.Range(5,10), -Random.Range(4,6));
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.collider.CompareTag("Player1") || target.collider.CompareTag("Player2"))
        {   
            Vector2 vel;
            vel.x = ballRigidBody2D.velocity.x;
            vel.y = (ballRigidBody2D.velocity.y / 2) + (target.collider.attachedRigidbody.velocity.y / 3);
            ballRigidBody2D.velocity = vel;
        }
        else
        {
            Vector2 vel;
            vel.x = ballRigidBody2D.velocity.x;
            vel.y = -ballRigidBody2D.velocity.y;
        }
    }
}
