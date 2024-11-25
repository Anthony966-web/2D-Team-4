using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Camera mainCamera;

    private SpriteRenderer spriteRenderer;
    public GameObject Weapon;
    private Rigidbody2D WeaponRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WeaponRb = Weapon.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x > 0;
        }

        movement = movement.normalized;

        RotateTowardsMouse();
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
    void RotateTowardsMouse()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Weapon.transform.position = new Vector2 (rb.position.x,rb.position.y);


        WeaponRb.rotation = angle;
    }
    public void physics()
    {
        rb.velocity = Vector3.zero;
    }
}
