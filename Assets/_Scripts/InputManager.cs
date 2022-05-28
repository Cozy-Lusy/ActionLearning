using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private Vector2 _moveDirection;
    private bool _escIsClicked;

    private void Start() 
    {
        if (Instance == null)
        {
            Instance = this;
        } 
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw(Constants.AXIS_X);
        float moveY = Input.GetAxisRaw(Constants.AXIS_Y);

        _moveDirection = new Vector2(moveX, moveY).normalized;

        _escIsClicked = Input.GetKeyDown(KeyCode.Escape);
    }

    #region Input api

    public Vector2 GetInput()
    {
        return _moveDirection;
    }

    public bool GetInputEsc()
    {
        return _escIsClicked;
    }

    #endregion
}
