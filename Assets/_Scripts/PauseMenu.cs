using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button buttonContinue;

    private bool _gameIsPaused = false;

    private void Update()
    {
        if (InputManager.Instance.GetInputEsc())
        {
            if (_gameIsPaused)
            {
                Resume();
            } else
            {
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
        _gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Constants.MAIN_MENU_INDEX);
    }
}
