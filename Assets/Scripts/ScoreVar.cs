using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreVar
{
    public static int p1Score;
    public static int p2Score;

    public static void Reset()
    {
        p1Score = p2Score = 0;
    }
}
