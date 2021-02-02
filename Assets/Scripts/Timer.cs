using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text textObj;
    float startGameTime = 60.0f;
    float gameTimer;
    //private int twoPlayer = PlayerSet.numPlayers;

    //float twoPlayerStartGameTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textObj = GetComponent<Text>();

        gameTimer = startGameTime;

        textObj.text = "Time: " + gameTimer.ToString("F2") + '\n' + "P1: " + ScoreVar.p1Score;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;

        textObj.text = "Time: " + gameTimer.ToString("F2") + '\n' + "P1: " + ScoreVar.p1Score;

        if (gameTimer <= 0)
        {
            gameTimer = 0f;

            print("game over!");
        }
    }

    /// <summary>
    /// Changes time.
    /// </summary>
    /// <param name="change">Increase timer by an amount.</param>
    public void changeTime(float change)
    {
        gameTimer += change;
    }
}
