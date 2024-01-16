using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChecker : MonoBehaviour
{
    private UIManager _uiManager;
    private GameManager _gameManager;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Could not find UIManager in FallChecker.");
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Could not find GameManager in FallChecker.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterController player = other.GetComponent<CharacterController>();
            if (player != null)
            {
                player.enabled = false;
                _uiManager.DisplayKilled();
                _gameManager.EndGame();
            }
            else
            {
                Debug.LogError("Could not get CharacterController in FallChecker.");
            }
        }
    }
}
