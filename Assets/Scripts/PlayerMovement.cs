using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 inputMovement;
    private Camera cam;
    private Vector2 mousePos;



    public Vector2 MovementDirection => inputMovement;
    public bool isMoving => inputMovement.magnitude > 0f;


    [SerializeField] float moveSpeed;
    [SerializeField] float dashSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    private void Update()
    {
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }


    private void FixedUpdate()
    {
        Movement();
    }
    private void Dash()
    {
        rb.velocity = Vector2.up * dashSpeed;
    }

    private void PlayerInput()
    {
        inputMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + inputMovement * moveSpeed * Time.fixedDeltaTime);

        Vector2 dir = mousePos - rb.position;
        //angulo = atan2(y, x)
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }
}
