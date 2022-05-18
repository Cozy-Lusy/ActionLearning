using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionData
{
    public string Query => query;
    public List<string> PossibleAnswer => possibleAnswer;
    public int CorrectAnswer => correctAnswer;

    [SerializeField] private string query;
    [SerializeField] private List<string> possibleAnswer;
    [SerializeField] private int correctAnswer;

    public static QuestionData GetEmptyQuestion()
    {
        return new QuestionData
        {
            query = "Пустой вопрос нет данных"
        };
    }
}
