using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public int MainMenuIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }
}
