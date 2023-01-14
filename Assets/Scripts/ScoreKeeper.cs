using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    TextMeshProUGUI player1Score;
    TextMeshProUGUI player2Score;
    Vector2 ballLocation;
    int[] allPossibleScores1 = {0,1,2,3,4,5,6,7};
    int[] allPossibleScores2 = {0,1,2,3,4,5,6,7};
    int count;

    void Awake()
    {
        player1Score = GameObject.Find("Player1 Counter").GetComponent<TextMeshProUGUI>();
        player2Score = GameObject.Find("Player2 Counter").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ballLocation = GameObject.Find("Ball").GetComponent<Rigidbody2D>().position;
        if(IncrementScoreCounterDependingOnWhoWins())
        {
            // count++;
        }

    }

    bool IncrementScoreCounterDependingOnWhoWins()
    {
        if(ballLocation.x > 8.25)
        {
            //count++;
            //counterPlayer1++;
            player1Score.SetText((count++).ToString());
            Debug.Log("Player 1 Scored!!!");
            return true;
        }
        else if(ballLocation.x < -8.25)
        {
            //count++;
            //counterPlayer2++;
            player2Score.SetText((count++).ToString());
            Debug.Log("Player 2 Scored!!!");
            return true;
        }
        return false;
    }
}
