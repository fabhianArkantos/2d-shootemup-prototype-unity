using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().AddScore();
            //GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>().AddScore(25);
        }
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
