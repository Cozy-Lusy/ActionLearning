using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var input = InputManager.Instance.GetInput();
        _rb.velocity = new Vector2(input.x * MoveSpeed, input.y * MoveSpeed);
    }
}
