using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings", order = 1)]
public class SettingsStorage : ScriptableObject
{
    public static SettingsStorage InstanceSettings { get; }

    [SerializeField] private List<Question> questions;

    public List<Question> GetQuestions()
    {
        return questions;
    }
}
