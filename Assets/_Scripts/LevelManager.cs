using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject FirstQuestionPanel;
    public GameObject WelcomePanel;
    public Question Questions;

    private bool _gameIsPaused = false;

    [SerializeField]
    private TextMeshProUGUI queryText;
    [SerializeField]
    private List<TextMeshProUGUI> buttonText;

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

        SetQuestion();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            EventFirstQuestion();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void EventFirstQuestion() 
    {
        EnablePanel(FirstQuestionPanel);
    }

    private void SetQuestion()
    {

        queryText.text = Questions.Query;

        if (buttonText.Count >= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                buttonText[i].text = Questions.PossibleAnswer[i];
            }
        }
    }

    public void SelectAnswer(int answer)
    {
        if (Questions.CorrectAnswer == answer)
        {
            DisablePanel(FirstQuestionPanel);
            Debug.Log("Correct");
        } else
        {
            Debug.Log("Wrong");
        }
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
