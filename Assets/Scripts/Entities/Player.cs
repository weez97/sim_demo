using System.Collections;
using System.Collections.Generic;
using EventTools;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        none, up, right, down, left
    }

    public enum State
    {
        idle, walking, running
    }

    private Direction direction;
    private State state;

    private float xInput, yInput;
    private float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        state = State.idle;
        direction = Direction.none;
    }

    private void Update()
    {
        ProcessInput();
        CustomEventHandler.AnimMovement(xInput, yInput, state, direction, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 move = new(xInput * moveSpeed * Time.deltaTime, yInput * moveSpeed * Time.deltaTime);
        rb.MovePosition(rb.position + move);
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
            CustomEventHandler.CallUiScreen("shop");

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (xInput != 0 || yInput != 0)
        {
            if (xInput < 0) direction = Direction.left;
            else if (xInput > 0) direction = Direction.right;
            else if (yInput < 0) direction = Direction.down;
            else direction = Direction.up;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = State.walking;
                moveSpeed = walkSpeed;
            }
            else
            {
                state = State.running;
                moveSpeed = runSpeed;
            }
        }
        else if (xInput == 0 && yInput == 0)
            state = State.idle;
    }
}
