using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int pointsToWin = 1;

    public Text scoreText1;
    public Text scoreText2;
    public Text winText;

    private int score1 = 0;
    private int score2 = 0;



    private void Start()
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }

    public void AddScoreP1(int amt)
    {
        score1 += amt;
        scoreText1.text = score1.ToString();

        if(score1 >= pointsToWin)
        {
            Time.timeScale = 0;
            winText.text = "PLAYER 1 WINS!";
        }
    }

    public void AddScoreP2(int amt)
    {
        score2 += amt;
        scoreText2.text = score2.ToString();

        if (score2 >= pointsToWin)
        {
            Time.timeScale = 0;
            winText.text = "PLAYER 2 WINS!";
        }
    }


}
