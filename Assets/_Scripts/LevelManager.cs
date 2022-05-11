using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject firstQuestionPanel;
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private TextMeshProUGUI queryText;
    [SerializeField] private List<TextMeshProUGUI> buttonText;
    [SerializeField] private SettingsStorage SettingsStorageSO;

    private bool _gameIsPaused = false;

    private void Start()
    {
        if (!welcomePanel.activeSelf)
        {
            if (_gameIsPaused)
            {
                DisablePanel(welcomePanel);
            }
            else
            {
                EnablePanel(welcomePanel);
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
        EnablePanel(firstQuestionPanel);
    }

    private void SetQuestion()
    {
        var questions = SettingsStorageSO.GetQuestions()[Constants.LEVEL1_QUESTION1];

        queryText.text = questions.GetQuery();

        if (buttonText.Count >= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                buttonText[i].text = questions.GetPossibleAnswer()[i];
            }
        }
    }

    public void SelectAnswer(int answer)
    {
        var possibleAnswer = SettingsStorageSO.GetQuestions()[Constants.LEVEL1_QUESTION1].GetCorrectAnswer();

        if (possibleAnswer == answer)
        {
            DisablePanel(firstQuestionPanel);
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
