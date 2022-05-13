using System;
using UnityEngine;

[Serializable]
public class Question
{
    public static InputManager InstanceQuestions { get; }

    [SerializeField] private string Query;
    [SerializeField] private string[] PossibleAnswer;
    [SerializeField] private int CorrectAnswer;

    public string GetQuery()
    {
        return Query;
    }

    public string[] GetPossibleAnswer()
    {
        return PossibleAnswer;
    }

    public int GetCorrectAnswer()
    {
        return CorrectAnswer;
    }
}
