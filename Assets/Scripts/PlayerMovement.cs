using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;

    [Header("Movement Info")]
    private Vector2 inputMovement;
    private Vector2 mousePos;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float moveSpeed;
    [SerializeField] int xLimit;
    [SerializeField] int yLimit;

    public Vector2 MovementDirection => inputMovement;
    public bool isMoving => inputMovement.magnitude > 0f;


    [Header("Dash Info")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    public float dashCooldown;
    [HideInInspector] public bool isDashing;
    private bool canDash = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    private void Update()
    {

        if (!GameManager.Instance.canPlay) {return;}

        if (isDashing) {return;}

        Boundaries();
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
            AudioManager.Instance.PlaySFX(2);
        }
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        Movement();
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        rb.velocity = transform.up * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        
        canDash = true;
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        inputMovement = new Vector2(horizontalInput, verticalInput);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Movement()
    {
        rb.velocity = (transform.up * verticalInput + Vector3.right * horizontalInput) * moveSpeed;

        Vector2 dir = mousePos - rb.position;
        //angulo = atan2(y, x)
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }

    private void Boundaries()
    {
        if (transform.position.x >= xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y);
        }
        if (transform.position.x <= -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y);
        }
        if (transform.position.y >= yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit);
        }
        if (transform.position.y <= -yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit);
        }
    }
    
}
