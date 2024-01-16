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

    public void DisplayInstructions()
    {
        _instructionText.text = "ASWD or Arrow keys to move.  E to climb up.  Left-Shift to roll.\nCollect the fires to complete the game and get to the end.";
    }

    public void DisplayKilled()
    {
        _instructionText.text = "Sorry.  You have died.  Press [1] to play again or [ESC] to exit.";
    }

    public void DisplayEnd()
    {
        _instructionText.text = "Congratulations.  You have put out all of the fires and made it to the end.  Press [1] to play again or [ESC] to exit.";
    }

}
