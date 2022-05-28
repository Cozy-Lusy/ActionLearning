using System;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public event Action OnLevelEnded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            OnLevelEnded?.Invoke();
        }
    }

}
