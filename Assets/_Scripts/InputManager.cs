using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector2 MoveDerection;

    private const string _axisX = "Horizontal";
    private const string _axisY = "Vertical";

    private void Update()
    {
        ProcessInputs();
    }

    public void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw(_axisX);
        float moveY = Input.GetAxisRaw(_axisY);

        MoveDerection = new Vector2(moveX, moveY).normalized;
    }
}
