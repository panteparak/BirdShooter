using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("Increment");
            GameControl.Instance.incrementScrore(5);
            Destroy(other.gameObject);
        }
    }
}
