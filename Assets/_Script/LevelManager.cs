using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject QuestionMove;

    private Vector2 _zeroPosition = new Vector2(0, 0);

    private void Start()
    {
        Time.timeScale = 1f; // Otherwise, the scene may be blocked
    }

    void Update()
    {
        EventMoveQuestion();
    }

    void EventMoveQuestion()
    {
        if ((InputManager.MoveDerection != _zeroPosition) && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            QuestionMove.SetActive(true);
        }
    }
}
