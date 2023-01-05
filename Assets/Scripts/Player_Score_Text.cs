using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Score_Text : MonoBehaviour
{   
    int PlayerScore1 = 0;
    int PlayerScore2 = 0;
    TextMeshPro playerText;

    void Start()
    {
        playerText = GetComponent<TextMeshPro>();
    }
    public void UpdatePlayerScore(int player){

        if(player == 1)
            playerText.text = "1";

            
    }
}
