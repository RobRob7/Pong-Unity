using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Initial ball position
    Vector3 ballInitialPosition;
    // 2D rigid body of Ball object
    Rigidbody2D ballRigidBody2D;
    // Player 1 paddle
    Rigidbody2D player1;
    // Player 2 paddle
    Rigidbody2D player2;
    // Initial player 1 and 2 paddle position
    Vector2 player1InitialPosition, player2InitialPosition;
    

    void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        player1 = GameObject.FindWithTag("Player1").GetComponent<Rigidbody2D>();
        player2 = GameObject.FindWithTag("Player2").GetComponent<Rigidbody2D>();
        player1InitialPosition = player1.position;
        player2InitialPosition = player2.position;
    } // end of Awake()

    // Start is called before the first frame update
    void Start()
    {   
        ballInitialPosition = new Vector3(0, 0, 0);
        Invoke("InitialLaunchOfBall", 3);
    } // end of Start()

    // Update is called once per frame
    void Update()
    {
        
    } // end of Update()

    public void ResetBallAndPlayerPositions()
    {
        ballRigidBody2D.velocity = new Vector2(0, 0);
        //ballInitialPosition = new Vector3(0, 0, 0);
        ballRigidBody2D.position = ballInitialPosition;
        player1.position = player1InitialPosition;
        player2.position = player2InitialPosition;
        Invoke("InitialLaunchOfBall", 3);
    } // end of ResetBallAndPlayerPositions()

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
    } // end of InitialLaunchOfBall()
}
