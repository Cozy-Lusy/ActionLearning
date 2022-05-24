using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private Button buttonOK;
    [SerializeField] private FinishLevel finishLevelTrigger;
    [SerializeField] private TextMeshProUGUI livesText;

    private static bool _gameIsPaused = false;
    private int _levelIndex;
    
    public static int LivesCount = 3;

    private void Start()
    {
        Time.timeScale = 1f;

        _levelIndex = SceneManager.GetActiveScene().buildIndex;
        Save();

        if (welcomePanel != null && !welcomePanel.activeSelf)
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

    private void Update()
    {
        livesText.text = $"{LivesCount}";
    }

    private void OnEnable()
    {
        if (finishLevelTrigger != null)
        {
            finishLevelTrigger.OnLevelEnded += CompleteLevel;
        }
        if (buttonOK != null)
        {
            buttonOK.onClick.AddListener(() => DisablePanel(welcomePanel));
        }
    }

    private void OnDisable()
    {
        if (finishLevelTrigger != null)
        {
            finishLevelTrigger.OnLevelEnded -= CompleteLevel;
        }
        if (buttonOK != null)
        {
            buttonOK.onClick.RemoveAllListeners();
        } 
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(_levelIndex + Constants.INCREMENT_INDEX_LEVEL);
    }

    public static void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
        FindObjectOfType<Player>().MoveSpeed = 0;
        _gameIsPaused = true;
    }

    public static void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        FindObjectOfType<Player>().MoveSpeed = 10;
        _gameIsPaused = false;
    }

    public void Save()
    {
        SaveManager.Save(Constants.SAVE_KEY, GetSaveSnapshot());
    }

    private SaveData GetSaveSnapshot()
    {
        var data = new SaveData()
        {
            SceneIndex = _levelIndex,
            Lives = LivesCount
        };

        return data;
    }
}
