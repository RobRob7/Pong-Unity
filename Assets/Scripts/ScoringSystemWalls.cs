using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystemWalls : MonoBehaviour
{
    BoxCollider2D wall;
    CircleCollider2D ball;
    TextMeshProUGUI player1ScoreText, player2ScoreText;
    int player1Count, player2Count;
    GameObject ballInGame;

    void Start()
    {
        ballInGame = GameObject.Find("Ball");
    }

    void Awake()
    {
        wall = GetComponent<BoxCollider2D>();
        ball = GameObject.FindWithTag("Ball").GetComponent<CircleCollider2D>();
        player1ScoreText = GameObject.FindWithTag("P1_Counter").GetComponent<TextMeshProUGUI>();
        player2ScoreText = GameObject.FindWithTag("P2_Counter").GetComponent<TextMeshProUGUI>();
        player1Count = player2Count = 0;
    }

    void OnTriggerEnter2D(Collider2D collidingObj)
    {
        if(collidingObj.CompareTag("Ball")){
            if(tag == "right_wall"){
                player1ScoreText.SetText((++player1Count).ToString());
                ballInGame.GetComponent<Ball>().ResetBallAndPlayerPositions();
            }
            else if(tag == "left_wall"){
                player2ScoreText.SetText((++player2Count).ToString());
                ballInGame.GetComponent<Ball>().ResetBallAndPlayerPositions();
            }
        }
    }
}
