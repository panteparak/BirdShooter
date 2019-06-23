using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool passedThrough;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0F;
    }

    void Update()
    {
        var position = transform.position;
        float speed = GameControl.Instance.getScore() / 1000;
        rigidBody.MovePosition(new Vector2 ((position.x - Math.Max(0.12f, speed)), position.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameControl.Instance.incrementScrore(5);
        }
        
    }
}
