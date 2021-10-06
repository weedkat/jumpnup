using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float flyForce;
    [SerializeField] private float flyDuration;
    public Transform groundPoint;
    public LayerMask WhatIsGround;
    private Rigidbody2D body;
    private bool isGrounded;
    private bool fly;
    private float flyTime;

    public enum PlayerState
    {
        Run,
        Jump,
        Fall,
        Dead,
    }


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public PlayerState state = PlayerState.Run;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, WhatIsGround);
        if (isGrounded)
        {
            flyTime = flyDuration;
            state = PlayerState.Run;
        }
        else
        {
            state = PlayerState.Fall;
        }
        body.velocity = new Vector2(1 * speed, body.velocity.y);
    }
    private void FixedUpdate()
    {
        if (fly && flyTime > 0)
        {
            body.velocity = new Vector2(body.velocity.x, flyForce);
            flyTime -= Time.deltaTime;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            state = PlayerState.Fall;
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    public void Fly(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            state = PlayerState.Jump;
            fly = true;
        }
        else
        {
            fly = false;
        }
    }
}
