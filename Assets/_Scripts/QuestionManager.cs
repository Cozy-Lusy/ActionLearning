using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private GameObject firstQuestionPanel;
    [SerializeField] private TextMeshProUGUI queryText;
    [SerializeField] private List<TextMeshProUGUI> buttonText;
    [SerializeField] private SettingsStorage settingsStorageSO;

    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonB;
    [SerializeField] private Button buttonC;
    [SerializeField] private Button buttonD;

    private void Start()
    {
        SetQuestion();
    }

    private void OnEnable()
    {
        buttonA.onClick.AddListener(() => SelectAnswer(1));
        buttonB.onClick.AddListener(() => SelectAnswer(2));
        buttonC.onClick.AddListener(() => SelectAnswer(3));
        buttonD.onClick.AddListener(() => SelectAnswer(4));
    }

    private void OnDisable()
    {
        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonC.onClick.RemoveAllListeners();
        buttonD.onClick.RemoveAllListeners();
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
        LevelManager.EnablePanel(firstQuestionPanel);
    }

    private void SetQuestion()
    {
        var questions = settingsStorageSO.GetQuestions()[Constants.LEVEL1_QUESTION1];

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
        var possibleAnswer = settingsStorageSO.GetQuestions()[Constants.LEVEL1_QUESTION1].GetCorrectAnswer();

        if (possibleAnswer == answer)
        {
            LevelManager.DisablePanel(firstQuestionPanel);
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
}
