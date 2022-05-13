using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button buttonContinue;

    private bool GameIsPaused = false;

    private void Update()
    {
        if (InputManager.Instance.GetInputEsc())
        {
            if (GameIsPaused)
            {
                Time.timeScale = 1f;
                Resume();
            } else
            {
                Time.timeScale = 0f;
                Pause();
            }
        }
    }

    private void OnEnable()
    {
        buttonContinue.onClick.AddListener(Resume);
    }

    private void OnDisable()
    {
        buttonContinue.onClick.RemoveAllListeners();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Constants.MAIN_MENU_INDEX);
    }
}
