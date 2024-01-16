using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private GameManager _gameManager;
    private MeshRenderer _display;
    private UIManager _uiManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Could not find GameManager in PressurePad.");
        }

        _display = GameObject.Find("Display").GetComponent<MeshRenderer>();
        if (_display == null)
        {
            Debug.LogError("Could not find Display in PressurePad.");
        }
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Could not find UIManager in PressurePad.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterController player = other.GetComponent<CharacterController>();
            if (player != null)
            {
                if (_gameManager.IsEndGame())
                {
                    player.enabled = false;
                    _uiManager.DisplayEnd();
                    _gameManager.EndGame();
                }
            }
            else
            {
                Debug.LogError("Could not get CharacterController in PressurePad.");
            }
        }
    }

    public void ShowExit()
    {
        _display.enabled = true;
    }
}
