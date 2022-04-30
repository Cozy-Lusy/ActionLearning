using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject FirstQuestionPanel;
    public GameObject WelcomePanel;

    private bool _gameIsPaused = false;

    private void Start()
    {
        if (!WelcomePanel.activeSelf)
        {
            if (_gameIsPaused)
            {
                DisablePanel(WelcomePanel);
            }
            else
            {
                EnablePanel(WelcomePanel);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            EventFirstQuestion();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void EventFirstQuestion() // This thing brings up a question window if the player has moved.
    {
        EnablePanel(FirstQuestionPanel);
    }

    public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }
}
