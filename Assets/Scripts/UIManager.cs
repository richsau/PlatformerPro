using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _playerScore;
    [SerializeField]
    private TMP_Text _playerTime;
    [SerializeField]
    private TMP_Text _instructionText;


    public void UpdateScore(string score)
    {
        if (_playerScore == null)
        {
            Debug.LogError("_playerScore NULL in UIManager.");
        }
        _playerScore.text = "Fires: " + score;
    }

    public void UpdateTime(string time)
    {
        if (_playerTime == null)
        {
            Debug.LogError("_playerTime NULL in UIManager.");
        }
        _playerTime.text = "Time: " + time;
    }
}
