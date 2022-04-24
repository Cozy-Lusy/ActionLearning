using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int NextSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }
}
