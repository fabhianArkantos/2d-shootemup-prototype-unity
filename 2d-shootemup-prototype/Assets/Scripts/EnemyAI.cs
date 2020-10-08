using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector2 reachPoint;
    private float speed = 5f;
    private float rotateFix = 90f;
    private Transform player;


    private Rigidbody2D rb;
    private FireScript fireScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireScript = GetComponent<FireScript>();
        
        reachPoint = new Vector2(transform.position.x , transform.position.y - 3);
        StartCoroutine(FireAndWait());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, reachPoint, speed * Time.deltaTime);
        HandleAiming();
    }

    private void HandleAiming()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotateFix;
        rb.rotation = angle;
    }

    IEnumerator FireAndWait()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            fireScript.Fire();
            yield return new WaitForSeconds(0.5f);
            fireScript.Fire();
            yield return new WaitForSeconds(0.5f);
            fireScript.Fire();
        }
    }
    
}
