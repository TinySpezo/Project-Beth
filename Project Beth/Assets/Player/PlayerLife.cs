using UnityEngine;
using UnityEngine.UIElements;
using System;

public class PlayerLife : MonoBehaviour
{

    public static event Action OnPlayerDeath;

    private bool alive = true;

    private void Update()
    {

        if (alive == false)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
