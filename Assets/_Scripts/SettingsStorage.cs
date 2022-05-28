using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings", order = 1)]
public class SettingsStorage : ScriptableObject
{
    [SerializeField] private List<QuestionData> questionsForLevel1;
    [SerializeField] private List<QuestionData> questionsForLevel2;

    private readonly Dictionary<int, List<QuestionData>> _storage = new Dictionary<int, List<QuestionData>>();

    public void Init()
    {
        _storage.Add(1, questionsForLevel1);
        _storage.Add(2, questionsForLevel2);
    }

    public List<QuestionData> GetQuestions(int levelIndex)
    {
        if (_storage.TryGetValue(levelIndex, out var questions))
        {
            return questions;
        }

        Debug.LogError("Вопросы не найдены");

        return new List<QuestionData>();
    }

    public void ClearStorage()
    {
        _storage.Clear();
    }
}
