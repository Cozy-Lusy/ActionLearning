using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private Button buttonLoad;

    private const string saveKey = "mainKey";

    private void OnEnable()
    {
        if (buttonLoad != null)
        {
            buttonLoad.onClick.AddListener(Load);
        }
    }

    private void OnDisable()
    {
        if (buttonLoad != null)
        {
            buttonLoad.onClick.RemoveAllListeners();
        }
    }

    public void Load()
    {
        var data = SaveManager.Load<SaveData>(saveKey);

        SceneManager.LoadScene(data.SceneIndex);
    }
}
