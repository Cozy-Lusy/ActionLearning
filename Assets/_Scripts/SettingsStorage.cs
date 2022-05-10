using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings", order = 1)]
public class SettingsStorage : ScriptableObject
{
    public List<Question> questions;
}
