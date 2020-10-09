using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform[] movePoints;
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[index].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints[index].position) < 0.2f)
        {
            if (index == movePoints.Length-1)
            {
                index = 0;
            }
            else
            {
                ++index;
            }
        }
    }
}
