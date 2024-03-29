﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource[] audioSources;
    private float current = 0;
    private string[] text = {"3", "2", "1", "START!"};
    private int pos = 0;

    [SerializeField] private Text countdown;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.Instance.isDead())
        {
            countdown.gameObject.SetActive(true);
            countdown.text = "Game Over!";
        }
        
        if (Time.time - current >= 1 && pos < text.Length)
        {
            current = Time.time;
            countdown.text = text[pos];
            Debug.Log(text[pos]);
            audioSources[pos <= 2 ? 0 : 1].Play();
            pos++;

            if (pos == text.Length)
            {
                countdown.gameObject.SetActive(false);
                GameControl.Instance.Gamestart();
            }
        }
    }
}
