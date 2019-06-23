using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : Singleton<GameControl>
{
    private long score = 0;
    private bool died = false;
    private bool gamestart = false;
    private bool gamecountdown = false;

    public void incrementScrore(long i)
    {
        if (!died)
        {
            Debug.Log("Increment");
            score += i;
        }
    }

    public long getScore()
    {
        return score;
    }

    public void BirdDied()
    {
        died = true;
    }

    public bool isDead()
    {
        return died;
    }
    public void Gamestart()
    {
        gamestart = true;
        died = false;
    }

    public void GameNotStart()
    {
        gamestart = false;
    }

    public bool getGameStart()
    {
        return gamestart;
    }

    public void ResetGame()
    {
        died = false;
        score = 0;
        gamestart = false;
        Debug.Log("reload");
    }

    public void StartCountDown()
    {
        gamecountdown = true;
    }
}
