using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField]
    public float upForce = 200f;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private static readonly int Flap = Animator.StringToHash("Flap");
    private static readonly int Die = Animator.StringToHash("Die");

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rigidBody.freezeRotation = true;
    }

    private void Update()
    {
        if (!GameControl.Instance.isDead())
        {
            CheckJump();
        }
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger(Flap);
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, upForce));
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("Boundary Hit");
            return;
        }
        
        animator.SetTrigger(Die);
        GameControl.Instance.BirdDied();
    }
}
