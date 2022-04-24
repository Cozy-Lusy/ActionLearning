using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D Rb;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Rb.velocity = new Vector2(InputManager.MoveDerection.x * MoveSpeed, InputManager.MoveDerection.y * MoveSpeed);
    }
}
