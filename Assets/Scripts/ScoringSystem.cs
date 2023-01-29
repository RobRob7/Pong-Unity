using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{

    BoxCollider2D leftWall, rightWall;
    CircleCollider2D ball;
    TextMeshProUGUI player1ScoreText, player2ScoreText;
    int player1Count, player2Count;

    void Awake()
    {
        leftWall = GameObject.FindWithTag("left_wall").GetComponent<BoxCollider2D>();
        rightWall = GameObject.FindWithTag("right_wall").GetComponent<BoxCollider2D>();
        ball = GameObject.FindWithTag("Ball").GetComponent<CircleCollider2D>();
        player1ScoreText = GameObject.FindWithTag("P1_Counter").GetComponent<TextMeshProUGUI>();
        player2ScoreText = GameObject.FindWithTag("P2_Counter").GetComponent<TextMeshProUGUI>();
        player1Count = player2Count = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // leftWall = GameObject.Find("Left Wall").GetComponent<BoxCollider2D>();
        // rightWall = GameObject.Find("Right Wall").GetComponent<BoxCollider2D>();
        // ball = GameObject.Find("Ball").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BallCollidesWithWall(ball);
    }

    public void BallCollidesWithWall(CircleCollider2D ball){
        if(leftWall.IsTouching(ball)){
            player2ScoreText.SetText((++player2Count).ToString());
        }
        if(rightWall.IsTouching(ball)){
            player1ScoreText.SetText((++player1Count).ToString());
        } 
    }
}
