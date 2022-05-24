using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private int levelIndex = -1;

    [SerializeField] private GameObject firstQuestionPanel;
    [SerializeField] private TextMeshProUGUI queryText;
    [SerializeField] private List<TextMeshProUGUI> buttonText;
    [SerializeField] private SettingsStorage settingsStorageSO;

    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonB;
    [SerializeField] private Button buttonC;
    [SerializeField] private Button buttonD;

    private List<QuestionData> _questionsForLevel = new List<QuestionData>();
    private int _curentQuestionIndex = 0;

    private void Start()
    {
        settingsStorageSO.Init();

        if (levelIndex < 0)
        {
            Debug.LogError("Не указан индекс уровня");
        }
        else
        {
            _questionsForLevel = settingsStorageSO.GetQuestions(levelIndex);
        }

        SetQuestion();

        Load();
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

    private QuestionData GetQuestion(int questionIndex)
    {
        if (questionIndex >= 0 && _questionsForLevel.Count < questionIndex)
        {
            Debug.LogError("Нет вопросов");

            return QuestionData.GetEmptyQuestion();
        }

        return _questionsForLevel[questionIndex];
    }

    private void SetQuestion()
    {
        var question = GetQuestion(_curentQuestionIndex);

        if (question is null)
        {
            Debug.Log("Вопросы отсутствуют");

            return;
        }

        queryText.text = question.Query;

        if (buttonText.Count >= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                buttonText[i].text = question.PossibleAnswer[i];
            }
        }
    }

    public void SelectAnswer(int answer)
    {
        var correctAnswer = GetQuestion(_curentQuestionIndex).CorrectAnswer;

        if (correctAnswer == answer)
        {
            LevelManager.DisablePanel(firstQuestionPanel);

            Debug.Log("Correct");

            _curentQuestionIndex++;
        }
        else
        {
            LevelManager.LivesCount--;
            
            Debug.Log("Wrong");
        }

        settingsStorageSO.ClearStorage();
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData>(Constants.SAVE_KEY);

        LevelManager.LivesCount = data.Lives;
    }
}
