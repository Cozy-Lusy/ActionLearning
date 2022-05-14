using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private Button buttonOK;
    [SerializeField] private FinishLevel finishLevelTrigger;

    private static bool _gameIsPaused = false;

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
    }

    private void OnEnable()
    {
        finishLevelTrigger.OnLevelEnded += CompleteLevel;

        buttonOK.onClick.AddListener(() => DisablePanel(welcomePanel));
    }

    private void OnDisable()
    {
        finishLevelTrigger.OnLevelEnded -= CompleteLevel;

        buttonOK.onClick.RemoveAllListeners();
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Constants.INCREMENT_INDEX_LEVEL);
    }

    public static void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
        GameObject.FindObjectOfType<Player>().MoveSpeed = 0;

        _gameIsPaused = true;
    }

    public static void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        FindObjectOfType<Player>().MoveSpeed = 10;
        _gameIsPaused = false;
    }
}
