using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerBody;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;


    public float speed;
    private float xMotion;
    private bool isMoving = false;
    private bool isAirborne = false;
    public float jumpForce;




    public Transform groundCheck;
    public LayerMask groundLayers;
    public float groundCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        speed = 15f;
        groundCheckRadius = .1f;
        jumpForce = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        isAirborne = !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        xMotion = Input.GetAxis("Horizontal");
        isMoving = xMotion != 0f;

    }


    private void FixedUpdate()
    {
        this.transform.position += new Vector3(speed * xMotion * Time.deltaTime, 0f, 0f);
        



        if (!isAirborne && Input.GetAxis("Jump")>0)
        {
            Debug.Log("Airborne");
            playerBody.velocity += new Vector2(0f, jumpForce);
        }

    }
}
