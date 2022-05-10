using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string AXIS_X = "Horizontal";
    private const string AXIS_Y = "Vertical";

    public static InputManager Instance { get; private set; }

    private Vector2 _moveDirection;

    private void Start() 
    {
        if (Instance == null) //Вход из главного меню на первый уровень может породить новый InputManager
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } 
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw(AXIS_X);
        float moveY = Input.GetAxisRaw(AXIS_Y);

        _moveDirection = new Vector2(moveX, moveY).normalized;
    }

    #region Input api

    public Vector2 GetInput()
    {
        return _moveDirection;
    }

    #endregion
}
