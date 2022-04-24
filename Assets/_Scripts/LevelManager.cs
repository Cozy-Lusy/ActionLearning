using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject MoveQuestionPanel;

    private Vector2 _zeroPosition = new Vector2(0, 0);

    private void Start()
    {
        Time.timeScale = 1f; // Otherwise, the scene may be blocked :C
    }

    private void Update()
    {
        EventMoveQuestion();
    }

    private void EventMoveQuestion() // This thing brings up a question window if the player has moved.
    {
        if ((InputManager.MoveDerection != _zeroPosition) && Time.timeScale != 0f) //Do not forget to check that the game is not stopped
        {
            //Time.timeScale = 0f;
            //MoveQuestionPanel.SetActive(true);
        }
    }
}
