using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] float _speed;
    Vector2 ballInitialPosition;
    Rigidbody2D ballRigidBody2D;
    GameObject scoreTracker1;
    GameObject scoreTracker2;
    int counter1 = 0;
    int counter2 = 0;

    void Awake()
    {
        //_speed = 3;
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        scoreTracker1 = GameObject.Find("Player1Scored");
        scoreTracker2 = GameObject.Find("Player2Scored");
    }

    // Start is called before the first frame update
    void Start()
    {   
      Invoke("InitialLaunchOfBall", 3);
    }

    // Update is called once per frame
    void Update()
    {

        if(ballRigidBody2D.position.x < -8.25 || ballRigidBody2D.position.x > 8.25)
        {
            
            ResetBall();
            //Invoke("InitialLaunchOfBall", 3);
        }
        //else
        // {
        //     counter1++;
        //     SendMessage("DisplayText", 1);
        //     ResetBall();
        // }
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
        Invoke("InitialLaunchOfBall", 1);
    }
    void InitialLaunchOfBall()
    {
        //float random = Random.Range(0,1);
        //float randomX = Random.Range(5,10);
        //float randomY = Random.Range(2,5);

        var rnd = new System.Random();
        double randDouble = rnd.NextDouble();


        if(randDouble < 0.25)
        {
            Debug.Log(randDouble);
            Debug.Log("First");
            ballRigidBody2D.velocity = new Vector2(Random.Range(5,10), -Random.Range(2,5));
        }
        else if(randDouble >= 0.25 && randDouble < 0.5)
        {
            Debug.Log(randDouble);
            Debug.Log("Second");
            ballRigidBody2D.velocity = new Vector2(Random.Range(5,10), Random.Range(2,5));
        }
        else if(randDouble >= 0.50 && randDouble < 0.75)
        {
            Debug.Log(randDouble);
            Debug.Log("Third");
            ballRigidBody2D.velocity = new Vector2(-Random.Range(5,10), Random.Range(2,5));
        }
        else if(randDouble >= 0.75 && randDouble <= 1.0)
        {
            Debug.Log(randDouble);
            Debug.Log("Fourth");
            ballRigidBody2D.velocity = new Vector2(-Random.Range(5,10), -Random.Range(2,5));
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
    }
}