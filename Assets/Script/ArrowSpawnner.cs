using System;
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
            Vector2 v = new Vector3(12.1f, Random.Range(-2.49f, 4.5f));
            Instantiate(arrow, v, new Quaternion(0f, 0f, 0.9f, 0.4f));
        }
    }

    private bool ShouldSpawn()
    {

        if (GameControl.Instance.isDead())
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
        long currentScore = GameControl.Instance.getScore();

        if (currentScore == 0L)
        {
            return 3f;
        }
        else
        {
            float spawn = 1 - (3f * (currentScore / 1000f));
            return Math.Min(spawn, 0.8f);
        }
    }
}
