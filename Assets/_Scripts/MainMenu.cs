using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonLoad;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonQuit;

    private const string saveKey = "mainKey";


    private void OnEnable()
    {
        buttonLoad.onClick.AddListener(LoadGame);
        buttonNewGame.onClick.AddListener(NewGame);
        buttonQuit.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        buttonLoad.onClick.RemoveAllListeners();
        buttonNewGame.onClick.RemoveAllListeners();
        buttonQuit.onClick.RemoveAllListeners();
    }

    public void LoadGame()
    {
        var data = SaveManager.Load<SaveData>(saveKey);

        SceneManager.LoadScene(data.SceneIndex);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(Constants.INCREMENT_INDEX_LEVEL);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
