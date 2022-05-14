using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionData
{
    public static InputManager InstanceQuestions { get; }

    [SerializeField] private string query;
    [SerializeField] private List<string> possibleAnswer;
    [SerializeField] private int correctAnswer;

    public string GetQuery()
    {
        return query;
    }

    public List<string> GetPossibleAnswer()
    {
        return possibleAnswer;
    }

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
}
