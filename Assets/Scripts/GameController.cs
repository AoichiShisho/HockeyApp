using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PuckController puckController;
    public MalletController mallet1Controller;
    public AIMalletController mallet2Controller;

    public int winningScore = 5;
    public Text scoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoalScored(int playerNumber)
    {
        if (playerNumber == 1) {
            player1Score++;
        } 
        else if (playerNumber == 2) {
            player2Score++;
        }

        UpdateScoreText();
        puckController.ResetPosition();

        mallet1Controller.ResetPosition();
        mallet2Controller.ResetPosition();
    }

    void UpdateScoreText()
    {
        scoreText.text = player1Score + " - " + player2Score;
    }
}
