using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public KeyCode Left = KeyCode.A, Right = KeyCode.D, Up = KeyCode.W, Down = KeyCode.S, Parry = KeyCode.Q;
    public float PlayerSpeed = 3;

    private Rigidbody2D rb;

    private Vector2 targetVelocity;
    private Vector2 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 inputDirection = Vector2.zero;

        if (Input.GetKey(Left)) inputDirection += Vector2.left;
        if (Input.GetKey(Right)) inputDirection += Vector2.right;
        if (Input.GetKey(Up)) inputDirection += Vector2.up;
        if (Input.GetKey(Down)) inputDirection += Vector2.down;

        if (inputDirection != Vector2.zero)
        {
            inputDirection = inputDirection.normalized;
            targetVelocity = inputDirection * PlayerSpeed;

            float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
        else
        {
            targetVelocity = Vector2.zero;
        }

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, 0.1f);
    }
}
