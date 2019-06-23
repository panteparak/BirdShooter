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
    private SceneLoader sceneLoader;
    private static readonly int Flap = Animator.StringToHash("Flap");
    private static readonly int Die = Animator.StringToHash("Die");

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sceneLoader = GetComponent<SceneLoader>();
        rigidBody.freezeRotation = true;
        rigidBody.isKinematic = true;
        GameControl.Instance.GameNotStart();
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameControl.Instance.ResetGame();
            sceneLoader.reload();
        }

        if (!GameControl.Instance.getGameStart())
        {
            return;
        }
        
        if (!GameControl.Instance.isDead())
        {
            rigidBody.isKinematic = false;
            CheckJump();
        }
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
