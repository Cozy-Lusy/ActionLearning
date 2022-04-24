using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(InputManager.MoveDerection.x * moveSpeed, InputManager.MoveDerection.y * moveSpeed);
    }
}
