using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    float player1Position;
    float player2Position;
    TextMeshProUGUI player1Score;
    TextMeshProUGUI player2Score;
    Vector2 ballLocation;
    int[] allPossibleScores1 = {0,1,2,3,4,5,6,7};
    int[] allPossibleScores2 = {0,1,2,3,4,5,6,7};
    int count1;
    int count2;
    int[] scoreKeeper = {0,0};

    void Awake()
    {
        player1Score = GameObject.Find("Player1 Counter").GetComponent<TextMeshProUGUI>();
        player2Score = GameObject.Find("Player2 Counter").GetComponent<TextMeshProUGUI>();
        player1Position = GameObject.Find("Player 1").GetComponent<Rigidbody2D>().position.x;
        player2Position = GameObject.Find("Player 2").GetComponent<Rigidbody2D>().position.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        count1 = 0;
        count2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ballLocation = GameObject.Find("Ball").GetComponent<Rigidbody2D>().position;
        if(IncrementScoreCounterDependingOnWhoScores() == true)
        {
            if(scoreKeeper[0] > 0){
                player1Score.SetText((KeepCountAndUpdate1()).ToString());
                wipeScoreKeeperArray();
            }
            
            if(scoreKeeper[1] > 0){
                player2Score.SetText((KeepCountAndUpdate2()).ToString());
                wipeScoreKeeperArray();
            }
        }

    }

    void wipeScoreKeeperArray(){
        scoreKeeper[0] = 0;
        scoreKeeper[1] = 0;
    }

    bool IncrementScoreCounterDependingOnWhoScores()
    {
        ballLocation = GameObject.Find("Ball").GetComponent<Rigidbody2D>().position;
        if(ballLocation.x > player2Position)
        {
            scoreKeeper[0]++;
            //count1++;
            //counterPlayer1++;
            //player1Score.SetText((KeepCountAndUpdate1()).ToString());
            //Debug.Log("Player 1 Scored!!!");
            return true;
        }
        if(ballLocation.x < player1Position)
        {
            scoreKeeper[1]++;
            //counterPlayer2++;
            //player2Score.SetText((KeepCountAndUpdate2()).ToString());
            //Debug.Log("Player 2 Scored!!!");
            return true;
        }
        return false;
    }

    int KeepCountAndUpdate1()
    {
        //Debug.Log(count1);
        ++count1;
        //Debug.Log(count1);
        return(count1);
    }

    int KeepCountAndUpdate2()
    {
        //Debug.Log(count2);
        ++count2;
        //Debug.Log(count2);
        return(count2);
    }
}
