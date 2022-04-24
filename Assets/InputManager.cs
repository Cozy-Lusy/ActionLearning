using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector2 MoveDerection;

    void Update()
    {
        ProcessInputs();
    }

    public void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDerection = new Vector2(moveX, moveY).normalized;
    }
}
