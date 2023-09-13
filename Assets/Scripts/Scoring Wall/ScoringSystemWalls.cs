using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystemWalls : MonoBehaviour
{
    // Player 1 and 2 score text
    TextMeshProUGUI player1ScoreText, player2ScoreText;
    // Current score of each player
    int player1Count, player2Count;
    // Current visibility of player scored text
    TextMeshProUGUI player1Scored, player2Scored;
    // The ball object
    GameObject ballInGame;

    // Start is called before the first frame update
    void Start()
    {
        // Find ball game object
        ballInGame = GameObject.Find("Ball");
    } // end of Start()

    // Called when the script instance is being loaded
    void Awake()
    {
        // Find player 1 score text
        player1ScoreText = GameObject.FindWithTag("P1_Counter").GetComponent<TextMeshProUGUI>();
        // Find player 2 score text
        player2ScoreText = GameObject.FindWithTag("P2_Counter").GetComponent<TextMeshProUGUI>();
        // Find player 1 scored
        player1Scored = GameObject.FindWithTag("player1Scored").GetComponent<TextMeshProUGUI>();
        // Find player 2 scored
        player2Scored = GameObject.FindWithTag("player2Scored").GetComponent<TextMeshProUGUI>();
        // Initialize both score counters to ZERO
        player1Count = player2Count = 0;
    } // end of Awake()

    // Check for enter collision with object
    void OnTriggerEnter2D(Collider2D collidingObj)
    {
        // Colliding object is the Ball object
        if(collidingObj.CompareTag("Ball")){
            // Colliding wall is the right wall
            if(tag == "right_wall")
            {
                //player2Scored.visibility;
                // Update player 1 score text and increment score count variable
                player1ScoreText.SetText((++player1Count).ToString());
                // Utilize resetting function of Ball class
                ballInGame.GetComponent<Ball>().ResetBallAndPlayerPositions();
            }
            // Colliding wall is the left wall
            else if(tag == "left_wall")
            {
                // Update player 2 score text and increment score count variable
                player2ScoreText.SetText((++player2Count).ToString());
                // Utilize resetting function of Ball class
                ballInGame.GetComponent<Ball>().ResetBallAndPlayerPositions();
            }
        }
    } // end of OnTriggerEnter2D(...)
}
