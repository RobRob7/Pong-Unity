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
    CircleCollider2D ballCollider2D;
    BoxCollider2D leftWallCollider2D, rightWallCollider2D;
    

    void Awake()
    {
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        player1 = GameObject.FindWithTag("Player1").GetComponent<Rigidbody2D>();
        player2 = GameObject.FindWithTag("Player2").GetComponent<Rigidbody2D>();
        player1Position = player1.position;
        player2Position = player2.position;
        ballCollider2D = GameObject.FindWithTag("Ball").GetComponent<CircleCollider2D>();
        leftWallCollider2D = GameObject.FindWithTag("left_wall").GetComponent<BoxCollider2D>();
        rightWallCollider2D = GameObject.FindWithTag("right_wall").GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {   
        Invoke("InitialLaunchOfBall", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBallAndPlayerPositions()
    {
        ballRigidBody2D.velocity = new Vector2(0, 0);
        ballInitialPosition = new Vector2(0, 0);
        ballRigidBody2D.MovePosition(ballInitialPosition);
        player1.position = player1Position;
        player2.position = player2Position;
        Invoke("InitialLaunchOfBall", 3);
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

    /*void RestartGame()

    {
        ResetBall();
        gameObject.GetComponent<PlayerController>().ResetPlayerPosition();
        Invoke("InitialLaunchOfBall", 1);
    }*/
    // void OnCollisionEnter2D(Collision2D target)
    // {
    //     if(target.collider.CompareTag("Left Wall")){
            
    //     }
    // }
}
