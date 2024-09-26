using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicManager : MonoBehaviour
{
    public float score;
    public TMP_Text scoreText;
    [HideInInspector] public bool gameOver = false;

    public void addPoints(){
        if (!gameOver){score = score + 1;}
    }

    public void gameLost(){
        gameOver = true;
        if (scoreText != null){scoreText.text = ("Final Score: " + score);}
    }

    void Update(){
        if (scoreText != null && !gameOver && score > 0){scoreText.text = (score.ToString());}
    }
}