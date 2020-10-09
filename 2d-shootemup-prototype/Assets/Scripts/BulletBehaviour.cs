using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
