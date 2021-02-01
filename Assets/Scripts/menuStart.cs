using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuStart : MonoBehaviour
{
   public void changeMenuSceneP1()
    {
        PlayerSet.numPlayers = 1;
        SceneManager.LoadScene("final_game");
    }
    public void changeMenuSceneP2()
    {
        PlayerSet.numPlayers = 2;
        SceneManager.LoadScene("final_game");
    }
    public void changeMenuScene()
    {
        ScoreVar.Reset();
        SceneManager.LoadScene("StartScreen");
    }
}
