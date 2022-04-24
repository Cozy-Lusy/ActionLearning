using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject questionMove;

    void Update()
    {
        EventMoveQuestion();
    }

    void EventMoveQuestion()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX != 0 || moveY != 0) && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            questionMove.SetActive(true);
        }
    }
}
