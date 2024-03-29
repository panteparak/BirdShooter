﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowSpawnner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject arrow;

    private float lastSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Debug.Log("Spawning Arrow");
            Vector2 v = new Vector3(12.1f, Random.Range(-2.49f, 4.5f));
            Instantiate(arrow, v, new Quaternion(0f, 0f, 0.9f, 0.4f));
        }
    }

    private bool ShouldSpawn()
    {

        if (GameControl.Instance.isDead() || !GameControl.Instance.getGameStart())
        {
            return false;
        }
        
        float current = Time.time;
        if (current - lastSpawn >= SpawnRate())
        {
            lastSpawn = current;
            return true;
        }

        return false;
    }

    private float SpawnRate()
    {
        const float BASE_SPEED = 1.95f;
        long currentScore = GameControl.Instance.getScore();

        if (currentScore/10 == 2L)
        {
            return BASE_SPEED;
        }
        else
        {
            float spawn = Math.Abs(BASE_SPEED - ((currentScore / 200f)));
            return Math.Max(spawn, 0.8f);
        }
    }
}
