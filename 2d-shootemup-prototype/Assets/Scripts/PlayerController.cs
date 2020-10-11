using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Physics
    [SerializeField]
    //[Range(5f, 15f)]
    private float speed = 10f;
    #endregion

    #region Variables
    private Vector2 movement;
    private bool isMoving;
    #endregion

    #region Components
    private Rigidbody2D rb2d;
    private FireScript fireScript;
    [SerializeField]
    private Transform[] firePoints;
    private Animator animator;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fireScript = GetComponent<FireScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement.x > 0 || movement.y > 0 || movement.x < 0 || movement.y < 0)
        {
            isMoving = true;
            animator.SetBool("isMoving",isMoving);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            fireScript.Fire(firePoints[0]);
            fireScript.Fire(firePoints[1]);
        }
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        rb2d.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);
    }
}
