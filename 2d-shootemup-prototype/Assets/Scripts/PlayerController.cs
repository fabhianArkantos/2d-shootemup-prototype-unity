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
    #endregion

    #region Components
    private Rigidbody2D rb2d;
    private FireScript fireScript;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fireScript = GetComponent<FireScript>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1"))
        {
            fireScript.Fire();
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition((Vector2) transform.position + movement * speed * Time.deltaTime);
        
    }
}
