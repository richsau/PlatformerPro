using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    private float _currentTime = 0f;
    private UIManager _uiManager;




    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Could not find UIManager in GameManager.");
        }
        _uiManager.UpdateScore(_score);
        //_uiManager.UpdateTime(_currentTime.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        _uiManager.UpdateTime(_currentTime.ToString("0.0"));
    }

    public void AddScore(int scoreAmount)
    {
        _score += scoreAmount;
        _uiManager.UpdateScore(_score);
    }

}
