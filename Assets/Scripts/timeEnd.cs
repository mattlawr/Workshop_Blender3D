using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeEnd : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (PlayerSet.numPlayers == 0)
        {
            text.text = "FINAL SCORE: " + ScoreVar.p1Score;
            ScoreVar.p1Score = 0;
            ScoreVar.p2Score = 0;
        }
        else
        {
            text.text = "P1: " + ScoreVar.p1Score.ToString() + '\n' + "P2: " + ScoreVar.p2Score.ToString();
            ScoreVar.p1Score = 0;
            ScoreVar.p2Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
