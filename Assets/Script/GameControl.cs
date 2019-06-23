using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : Singleton<GameControl>
{
    private long score = 0;
    private bool died = false;

    public void incrementScrore(long i)
    {
        if (!died)
        {
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
}
